import { ChangeHandler } from '../ChangeHandler/ChangeHandler';
import { GameRenderer } from './GameRenderer';
import { GameState } from '../GameState/GameState';
import { ILayer } from '../GameState/ILayer';
import { IInteractiveObject } from '../GameState/IInteractiveObject';
import { ICharacter } from '../GameState/ICharacter';
import { IPlayer } from '../GameState/IPlayer';
import Phaser from 'phaser';

const sceneConfig: Phaser.Types.Scenes.SettingsConfig = {
    active: false,
    visible: false,
    key: 'MainGame',
};

export class MainGame extends Phaser.Scene {

    private changeHandler: ChangeHandler;
    private gameRenderer: GameRenderer;
    private cursors!: Phaser.Types.Input.Keyboard.CursorKeys;
    private tiles!: Phaser.GameObjects.Group;
    private npcs!: Phaser.GameObjects.Group;
    private interactiveObjects!: Phaser.GameObjects.Group;
    private healthText!: Phaser.GameObjects.Text;
    private goldText!: Phaser.GameObjects.Text;
    private experienceText!: Phaser.GameObjects.Text;
    private damageText!: Phaser.GameObjects.Text;

    private up: boolean = false;
    private down: boolean = false;
    private right: boolean = false;
    private left: boolean = false;

    constructor(changeHandler: ChangeHandler) {
        super(sceneConfig);
        this.changeHandler = changeHandler;
        this.gameRenderer = new GameRenderer(this, 3);
    }

    public preload() {
        this.load.setBaseURL('https://oijfspafakporsfs-dungeon.fra1.digitaloceanspaces.com/');
        this.load.image('floor', 'floor.png');
        this.load.image('spawn', 'floor_entrance.png');
        this.load.image('exit', 'floor_ladder.png');
        this.load.image('wall', 'wall.png');
        this.load.image('chest', 'chest.png');
        this.load.image('chest_empty', 'chest_open.png');
        this.load.image('chest_mimic', 'chest_mimic.png');
        this.load.spritesheet('mob', 'mob.png', { frameWidth: 16, frameHeight: 20 });
        this.load.spritesheet('knight', 'knight.png', { frameWidth: 16, frameHeight: 28 });
    }

    public create() {
        // Create cursors, groups and text objects.
        this.cursors = this.input.keyboard.createCursorKeys();
        this.tiles = this.add.group();
        this.npcs = this.add.group();
        this.interactiveObjects = this.add.group();
        this.healthText = this.add.text(16, 16, '', { fontSize: '20px' });
        this.goldText = this.add.text(16, 45, '', { fontSize: '20px' });
        this.experienceText = this.add.text(16, 74, '', { fontSize: '20px' });
        this.damageText = this.add.text(200, 16, '', { fontSize: '20px' });

        // Create animations
        this.anims.create({
            key: 'knight_idle',
            frames: this.anims.generateFrameNumbers('knight', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1,
        });

        this.anims.create({
            key: 'mob_idle',
            frames: this.anims.generateFrameNumbers('mob', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1,
        });

        // Get gamestate from server.
        this.changeHandler!.getState().then((r) => {
            this.drawFromState(r);
        });
    }

    public update() {
        // If cursor is down, set flag, once no longer held and flag is set call changeHandler in desired direction
        if (this.cursors!.left!.isDown) {
            this.left = true;
        }

        if (this.left && this.cursors!.left!.isUp) {
            this.left = false;
            this.changeHandler.move('Left').then((r) => {
                this.cleanUp();
                this.drawFromState(r);
            });
        }

        if (this.cursors.right!.isDown) {
            this.right = true;
        }

        if (this.right && this.cursors.right!.isUp) {
            this.right = false;
            this.changeHandler.move('Right').then((r) => {
                this.cleanUp();
                this.drawFromState(r);
            });
        }

        if (this.cursors.up!.isDown) {
            this.up = true;
        }

        if (this.up && this.cursors.up!.isUp) {
            this.up = false;
            this.changeHandler.move('Up').then((r) => {
                this.cleanUp();
                this.drawFromState(r);
            });
        }

        if (this.cursors.down!.isDown) {
            this.down = true;
        }

        if (this.down && this.cursors.down!.isUp) {
            this.down = false;
            this.changeHandler.move('Down').then((r) => {
                this.cleanUp();
                this.drawFromState(r);
            });
        }
    }

    private cleanUp() {
        this.npcs.clear(true, true);
        this.tiles.clear(true, true);
        this.interactiveObjects.clear(true, true);
    }

    private drawFromState(state: GameState) {
        // Get objects from state
        const layer: ILayer = state.layerState;
        const playerState: IPlayer = state.playerState;
        const characters: (ICharacter | null)[][] = layer.getCharacters();
        const interObjects: (IInteractiveObject | null)[][] = layer.getInteractiveObjects();

        // Use objects to render state with gameRenderer.
        this.tiles = this.gameRenderer.renderLayer(layer);
        this.interactiveObjects = this.gameRenderer.renderInteractiveObjects(interObjects);
        this.npcs = this.gameRenderer.renderCharacters(characters);
        this.gameRenderer.updateHealth(this.healthText, playerState.health, playerState.maxHealth);
        this.gameRenderer.updateGold(this.goldText, playerState.gold);
        this.gameRenderer.updateExperience(this.experienceText, playerState.experience);
        this.gameRenderer.updateDamage(this.damageText, playerState.damage);
    }
}
