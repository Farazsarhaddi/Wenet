# models.py
class GeoPoint:
    def __init__(self, id, x, y):
        self.ID = id
        self.X = x
        self.Y = y

# تابع برای گرفتن نقطه بر اساس ID
def getbyID(id):
    point1 = GeoPoint(1, 51.1, 35.5)
    point2 = GeoPoint(2, 52.3, 34.3)
    point3 = GeoPoint(3, 53.2, 32.3)
    Points = [point1, point2, point3]
    
    for pt in Points:
        if pt.ID == id:
            return pt
    return GeoPoint(-1, 0, 0)  # نقطه نامعتبر




