FROM ubuntu/ubuntu:latest

USER root

RUN apt-get update -y && \
    apt-get upgrade -y && \
	apt-get install -y git

RUN apt-get -y install apt-transport-https && \
    wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get -y update && \
    apt-get -y upgrade && \
    apt-get -y install dotnet-sdk-3.0 dotnet-sdk-2.1 

RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -  && \
    apt-get install -y nodejs

RUN git clone https://github.com/Hogfeldt/dungeon-crawler.git

USER ubuntu