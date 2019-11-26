

# Pull newest and remove old containers
git pull

docker container stop api
docker container stop client

docker container rm api
docker container rm client

# build new containers
cd clientApp

docker image build -t clientapp .
cd ../ServerApp
docker image build -t serverapp .

# Deploy containers
docker container run -d -p 5000:5000 -p 5001:5001 --name api serverapp
docker container run -d -p 8080:8080 --name client clientapp
