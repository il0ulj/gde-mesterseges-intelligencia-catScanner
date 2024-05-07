# GDE
## Mesterséges intelligencia tantárgy
### catScanner beadandó feladat leírása

Yolov5-ben készítsenek egy onnx modell-t pythonban (jupiter vagy visual studio), mely minimum 1 kategóriát tartalmaz. A dataset-et Önök címkézzék fel hozzá. Készítsenek egy .Net alkalmazást (Windows form vagy Blazor), mely a kameráról készített vagy egy feltöltött képet elemez az onnx modell-t használva. .Net alkalmazásban a grafikus megjelenítéssel keretezzék be az objektumot, és írják ki a label-t (mit talált), valamint a predikciót (mekkora valószínûséggel ismerte fel az címkéjû objektumot a modell).
Tömörített fájlként küldjék el, mely állomány az alábbiakat tartalmazza:
- dataset (képek, címkézés adatai, stb, train, validation és test mappa is)
- python kód, amelyben a tréninget készítették
- onnx fájl
- .Net alkalmazás

### Installation steps (included separated and numbered scripts in yolov5 directory)
#### Create and install requirements
```
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
```
#### Get images
Run 01_get_images.py python script the way like this:
```
python3 01_get_images.py python
```
#### Train
```
cd /opt/yolov5
python3 train.py --img 640 --epochs 300 --data macska.yaml --weights yolov5s.pt
```
#### Export
```
cd /opt/yolov5/runs/train/exp/weights
python3 export.py --weights best.pt --include onnx
```
