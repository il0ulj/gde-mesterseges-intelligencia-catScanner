#!/bin/bash

cd /opt/yolov5
python3 train.py --img 640 --epochs 300 --data macska.yaml --weights yolov5s.pt