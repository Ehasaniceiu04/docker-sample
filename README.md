# docker-sample



### Stop / remove all Docker containers

One liner to stop / remove all of Docker containers:

<pre>docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)</pre>


To delete all the images,

<pre>docker rmi -f $(docker images -a -q)</pre>
