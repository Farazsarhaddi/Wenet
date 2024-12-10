# myapp/urls.py
from django.urls import path
from . import views

urlpatterns = [
    path('', views.home, name='home'),  # مسیر برای صفحه اصلی
    path('api/perimeter/', views.calculate_perimeter, name='calculate_perimeter'),
]
