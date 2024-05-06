# GDE
## Mesterséges intelligencia tantárgy
### catScanner beadandó feladat leírása

Yolov5-ben készítsenek egy onnx modell-t pythonban (jupiter vagy visual studio), mely minimum 1 kategóriát tartalmaz. A dataset-et Önök címkézzék fel hozzá. Készítsenek egy .Net alkalmazást (Windows form vagy Blazor), mely a kameráról készített vagy egy feltöltött képet elemez az onnx modell-t használva. .Net alkalmazásban a grafikus megjelenítéssel keretezzék be az objektumot, és írják ki a label-t (mit talált), valamint a predikciót (mekkora valószínûséggel ismerte fel az címkéjû objektumot a modell).
Tömörített fájlként küldjék el, mely állomány az alábbiakat tartalmazza:
- dataset (képek, címkézés adatai, stb, train, validation és test mappa is)
- python kód, amelyben a tréninget készítették
- onnx fájl
- .Net alkalmazás
