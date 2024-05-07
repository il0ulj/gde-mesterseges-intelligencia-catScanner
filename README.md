# GDE
## Mesters�ges intelligencia tant�rgy
### catScanner beadand� feladat le�r�sa

Yolov5-ben k�sz�tsenek egy onnx modell-t pythonban (jupiter vagy visual studio), mely minimum 1 kateg�ri�t tartalmaz. A dataset-et �n�k c�mk�zz�k fel hozz�. K�sz�tsenek egy .Net alkalmaz�st (Windows form vagy Blazor), mely a kamer�r�l k�sz�tett vagy egy felt�lt�tt k�pet elemez az onnx modell-t haszn�lva. .Net alkalmaz�sban a grafikus megjelen�t�ssel keretezz�k be az objektumot, �s �rj�k ki a label-t (mit tal�lt), valamint a predikci�t (mekkora val�sz�n�s�ggel ismerte fel az c�mk�j� objektumot a modell).
T�m�r�tett f�jlk�nt k�ldj�k el, mely �llom�ny az al�bbiakat tartalmazza:
- dataset (k�pek, c�mk�z�s adatai, stb, train, validation �s test mappa is)
- python k�d, amelyben a tr�ninget k�sz�tett�k
- onnx f�jl
- .Net alkalmaz�s

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
