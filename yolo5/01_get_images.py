import argparse
import json
import os
import time
import requests
import tqdm

from pexels_api import API
from PIL import Image

PAGE_LIMIT = 30
RESULT_PER_PAGE = 10

PEXELS_API_KEY = '9ii54S0A8A9uJ5mGa4yeWkBUytzUcY9l2BKT1RiydBHvtJQSe0OufgY3'

api = API(PEXELS_API_KEY)
query = 'cat'
photos_dict = {}
page = 1
counter = 0

while page <= PAGE_LIMIT:
  api.search(query, page=page, results_per_page=RESULT_PER_PAGE)
  photos = api.get_entries()
  for photo in tqdm.tqdm(photos):
    photos_dict[photo.id] = vars(photo)['_Photo__photo']
    counter += 1
    if not api.has_next_page:
      break
  page += 1
  time.sleep(2)

print(f"Finishing at page: {page}")
print(f"Images were processed: {counter}")

PATH = "_pictures/"
RESOLUTION = "original"
IMAGE_SIZE = (640, 640)

if photos_dict:
  os.makedirs(PATH, exist_ok=True)

  with open(os.path.join(PATH, f'{query}.json'), 'w') as fout:
    json.dump(photos_dict, fout)

for val in tqdm.tqdm(photos_dict.values()):
  url = val['src'][RESOLUTION]
  fname = os.path.basename(val['src']['original'])
  image_path = os.path.join(PATH, fname)
  if not os.path.isfile(image_path):
    response = requests.get(url, stream=True)
    with open(image_path, 'wb') as outfile:
      outfile.write(response.content)

    with Image.open(image_path) as img:
      img = img.resize(IMAGE_SIZE)
      img.save(image_path)

  else:
    print(f"File: {image_path} exist")