#!/bin/bash

# Change directory to /opt
cd /opt

# Create mi directory under /opt
sudo mkdir mi

# Create _pictures directory under /opt
sudo mkdir _pictures

# Unzip dataset
sudo unzip macska.v1iyolov55pytorch.zip

# Unzip copied yolov5
sudo unzip yolov5.zip

# Update package repository
sudo apt install update

# Install reuqired python3 packages
sudo install python3 python3-pip

# Change directory to /opt/yolov5
cd yolov5

# Install yolov5 reuqirement packages
pip3 install -r requirements.txt
