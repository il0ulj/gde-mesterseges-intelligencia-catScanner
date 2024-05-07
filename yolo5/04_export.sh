#!/bin/bash

cd /opt/yolov5/runs/train/exp/weights
python3 export.py --weights best.pt --include onnx