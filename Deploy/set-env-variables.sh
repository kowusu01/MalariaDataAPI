#!/bin/sh


export DataSourceType=Server

export DBServer=dev.postgres.db:5432
export DBInstance=malariadb_dev
export DBUsername=postgres
export DBPassword=postgrespw

export POSTGRES_USER=postgres
export POSTGRES_PASSWORD=postgrespw

export PGDATA=/var/lib/postgresql/data/pgdata

# app reader mount volumes

export POSTGRES_DATA_FILES_VOLUME_SOURCE=/home/zkot2/postgres/dbfiles
export POSTGRES_DATA_FILES_VOLUME_TARGET=/var/lib/postgresql/data

export FS_READER_DATA_VOLUME_SOURCE=/home/zkot2/app_data/fsreader/data
export FS_READER_DATA_VOLUME_TARGET=/usr/local/src/fsreader/data

export FS_READER_COMPLETED_VOLUME_SOURCE=/home/zkot2/app_data/fsreader/data/completed
export FS_READER_COMPLETED_VOLUME_TARGET=/usr/local/src/fsreader/data/completed           

export FS_READER_BAD_VOLUME_SOURCE=/home/zkot2/app_data/fsreader/data/bad
export FS_READER_BAD_VOLUME_TARGET=/usr/local/src/fsreader/data/bad