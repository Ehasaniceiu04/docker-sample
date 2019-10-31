### Stop / remove all Docker containers

One liner to stop / remove all of Docker containers:

<pre>docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)</pre>


To delete all the images,

<pre>docker rmi -f $(docker images -a -q)</pre>


To build docker image

<pre> docker build -t ngapp . </pre>

To run docker container

<pre> docker run -p 4200:80 ngapp </pre>

To build docker images using docker compose

<pre> docker-compose build </pre>

To run docker containers using docker compose

<pre> docker-compose up </pre>


To stop docker containers using docker compose

<pre> docker-compose stop </pre>


To remove docker containers using docker compose
<pre> docker-compose down </pre>
