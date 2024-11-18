from django.http import JsonResponse  # Importing JsonResponse to return JSON responses
from .models import User  # Importing the User model from the models module
import sqlite3  # Importing sqlite3 to interact with the SQLite database directly

def check_user(request, username, password):
    # Connect to the SQLite database using the given path
    con = sqlite3.connect("C:\\Users\\0&1\\Wenet\\Exercise\\E13\\myproject\\usersdatabase.db")
    cur = con.cursor()  # Create a cursor object to execute SQL queries

    # Execute an SQL query to select the user with the given username
    res = cur.execute("SELECT id, username, password FROM users WHERE username=?", (username,)).fetchone()
    con.close()  # Close the database connection

    # Check if the query returned a result
    if res:
        # If a user is found, compare the provided password with the stored password
        if res[2] == password:
            # If the password matches, return a JSON response with message 'True'
            return JsonResponse({
                'message': 'True',
            }, status=200)
        else:
            # If the password does not match, return an 'Invalid password' message
            return JsonResponse({'message': 'Invalid password'}, status=401)
    else:
        # If no user is found, return a 'False' message
        return JsonResponse({'message': 'False'}, status=404)



