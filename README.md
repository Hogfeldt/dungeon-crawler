# dungeon-crawler
prj4 prodcut repo


## Prerequisite

! NOTE ! This is not a guide on how to install nodjs or npm.

Vue/Cli and Nodjs sould be installed, which also should contain npm. This was created using node-version: 12.13.0 and npm-version: 6.12.0. If you have an older version, there are no guaranty that this setup will work.

You can check your node version by runnig the following command in your terminal:

```
node -v
```

similar for npm:

```
npm -v
```

### (A small) Installation Guide

Download and Install nodejs from: [https://nodejs.org/en/download/].
This should also give you npm. 


### Update Guide
I dont know. google it, I guess.

## How to use

### Install and Run (no build info)
Clone the repository, and run the following command inside the boiler-folder:

```
npm install
```
After installing, everything should be set up to start developing as a normal Vue-project, with the added features of typescript and phaser. 

Run the following command to test your webapp (runnig at [http://localhost:8080)]:

```
npm run serve
```

If this fails, you should check your node and npm version-number (See Prerequisite). If this is not the problem, Sivert is a goof, and it is probably his fault.

### About Development

The boilerplate is set up such that there are one vue-file that handles the app (App.vue), and one vue-file that handles all the typescript-files (Main.vue). Development in Main.vue will primarily happen in the 'script' section, you dont need to add anything to the 'template' or 'style' section, see [https://phaser.io/]  for guids on how to render images on screen with only Phaser and typescript. 

In Main.vue, get access to typescript files through the following line

```
import { ClassName } from './ClassNameFile'
```

The ClassName parameter are the class you exported from your ClassNameFile.ts. There shouldn't be any type (.ts) after your filename, only the path and the filename itself.

Primarly will development happen in seperate typescript-files, located in the scr/components dir., and resources (such as sprites and images) in scr/assets, using the main.vue as a client. You are free to mess around with App.vue, and everything else, but note that this would be working more with set-up than development. 

## Example Code

#### INPC.ts:
An interface (INPC) that contains some basic NPC traits, and an print-funciton. 

#### NPCMonster.ts
Imports the INPC-interface.
Creates an instance of INPC, class NPCMonster that extends INPC. Has som addition parameters for the NPCMonster.
Defines one constructor, and a print-function.

#### Main.vue
Imports the NPCMonster-class, creates a new monster, and prints it.

#### Running the program
First off, ignore the warnings. Linter doesn't like console.log, but it's all good. 
When runnig the program, you will be presented with an blank page that greets you with a friendly 'Hello' (remember to say hello back, don't be rude).
If you right-click -> choose inspect element -> go to the console tab, you will se some outputs from the program. 


## Other

For tutorial and documentation, check out phasers homepage: [https://phaser.io/]










