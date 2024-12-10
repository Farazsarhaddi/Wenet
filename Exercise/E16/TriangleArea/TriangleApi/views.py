from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
import json
from math import radians, sin, cos, sqrt, atan2

# تابع برای محاسبه فاصله بین دو نقطه با استفاده از فرمول هاروو سین
def haversine(lat1, lon1, lat2, lon2):
    R = 6371  # شعاع زمین به کیلومتر
    lat1 = radians(lat1)
    lon1 = radians(lon1)
    lat2 = radians(lat2)
    lon2 = radians(lon2)

    dlat = lat2 - lat1
    dlon = lon2 - lon1

    a = sin(dlat / 2) ** 2 + cos(lat1) * cos(lat2) * sin(dlon / 2) ** 2
    c = 2 * atan2(sqrt(a), sqrt(1 - a))

    return R * c  # فاصله به کیلومتر

# CSRF را غیرفعال می‌کند (برای تست و توسعه)
@csrf_exempt
def calculate_perimeter(request):
    if request.method == 'POST':
        data = json.loads(request.body)
        lat1 = data['lat1']
        lon1 = data['lon1']
        lat2 = data['lat2']
        lon2 = data['lon2']
        lat3 = data['lat3']
        lon3 = data['lon3']

        # محاسبه طول هر ضلع مثلث
        side1 = haversine(lat1, lon1, lat2, lon2)
        side2 = haversine(lat2, lon2, lat3, lon3)
        side3 = haversine(lat3, lon3, lat1, lon1)

        # محاسبه محیط مثلث
        perimeter = side1 + side2 + side3

        return JsonResponse({'perimeter': perimeter})

    return JsonResponse({'error': 'Invalid request'}, status=400)


# myapp/views.py
from django.shortcuts import render

def home(request):
    return render(request, 'TriangleApi/TriangleForm.html')  # مسیر فایل HTML

