# views.py
from django.http import JsonResponse
from math import radians, sin, cos, sqrt, atan2

# تابع برای محاسبه فاصله بین دو نقطه با استفاده از فرمول هاروسین
def haversine_distance(lat1, lon1, lat2, lon2):
    R = 6371000  # شعاع زمین به متر
    phi1, phi2 = radians(lat1), radians(lat2)
    delta_phi = radians(lat2 - lat1)
    delta_lambda = radians(lon2 - lon1)
    
    a = sin(delta_phi / 2.0) ** 2 + cos(phi1) * cos(phi2) * sin(delta_lambda / 2.0) ** 2
    c = 2 * atan2(sqrt(a), sqrt(1 - a))
    
    return R * c

# تابع برای گرفتن نقطه بر اساس ID
class GeoPoint:
    def __init__(self, id, x, y):
        self.ID = id
        self.X = x
        self.Y = y

def getbyID(id):
    point1 = GeoPoint(1, 51.1, 35.5)
    point2 = GeoPoint(2, 52.3, 34.3)
    point3 = GeoPoint(3, 53.2, 32.3)
    Points = [point1, point2, point3]
    
    for pt in Points:
        if pt.ID == id:
            return pt
    return GeoPoint(-1, 0, 0)  # نقطه نامعتبر

# ویوی محاسبه محیط مثلث
def calculate_perimeter(request):
    try:
        # گرفتن شناسه‌ها از پارامترهای query
        id1 = int(request.GET.get('id1'))
        id2 = int(request.GET.get('id2'))
        id3 = int(request.GET.get('id3'))

        # دریافت نقاط با استفاده از تابع getbyID
        point1 = getbyID(id1)
        point2 = getbyID(id2)
        point3 = getbyID(id3)

        # بررسی صحت وجود نقاط
        if point1.ID == -1 or point2.ID == -1 or point3.ID == -1:
            return JsonResponse({'error': 'One or more points not found'}, status=404)

        # محاسبه طول اضلاع مثلث
        side1 = haversine_distance(point1.Y, point1.X, point2.Y, point2.X)
        side2 = haversine_distance(point2.Y, point2.X, point3.Y, point3.X)
        side3 = haversine_distance(point3.Y, point3.X, point1.Y, point1.X)

        # محاسبه محیط
        perimeter = side1 + side2 + side3
        
        return JsonResponse({'perimeter': perimeter})
    
    except (TypeError, ValueError):
        return JsonResponse({'error': 'Invalid input'}, status=400)
