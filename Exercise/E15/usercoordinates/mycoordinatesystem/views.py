from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
import json
from .models import UserLocation
from django.shortcuts import render


@csrf_exempt  # Disables CSRF protection for this view, allowing API clients to make POST requests without CSRF tokens
def save_location(request):
    if request.method == 'POST': 
        try:
            # Parse the JSON data from the request body
            data = json.loads(request.body)
            latitude = data.get('latitude')  # Extract latitude from the JSON data
            longitude = data.get('longitude')  # Extract longitude from the JSON data
            
            if latitude and longitude:  
                # Create a new UserLocation entry in the database
                UserLocation.objects.create(latitude=latitude, longitude=longitude)
                return JsonResponse({'status': 'success', 'message': 'Location saved'})  
            else:
                # Return an error response if data is missing or invalid
                return JsonResponse({'status': 'error', 'message': 'Invalid data'}, status=400)
        except Exception as e:
            # Handle exceptions and return an error response with the exception message
            return JsonResponse({'status': 'error', 'message': str(e)}, status=500)
    
    # Return an error response for HTTP methods other than POST
    return JsonResponse({'status': 'error', 'message': 'Invalid request method'}, status=405)


def location_count(request):
    count = UserLocation.objects.count()  # Count the total number of UserLocation entries in the database
    return JsonResponse({'count': count})  # Return the count as JSON response

# View to render the coordinates system page
def my_view(request):
    return render(request, 'mycoordinatesystem/coordinatesystem.html') 
