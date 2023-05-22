 #!/usr/bin/env bash

 mkdir /home/zkot2/postgres
 mkdir /home/zkot2/postgres/dbfiles

 mkdir /home/zkot2/app_data
 mkdir /home/zkot2/app_data/fsreader
 mkdir /home/zkot2/app_data/fsreader/data
 mkdir /home/zkot2/app_data/fsreader/data/complete
 mkdir /home/zkot2/app_data/fsreader/data/bad

docker system prune --all --volumes

docker network create containers-network

