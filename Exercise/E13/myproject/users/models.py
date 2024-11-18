from django.db import models  # Importing the models module from Django to define database models

# Model representing user information with unique user_id, name, and email fields
class UserInfo(models.Model):
    user_id = models.IntegerField(unique=True)  # Unique identifier for the user
    name = models.CharField(max_length=100)  # Name of the user, with a maximum length of 100 characters
    email = models.EmailField()  # Email field for the user's email address

# Model representing user credentials with username and password fields
class User(models.Model):
    username = models.CharField(max_length=100)  # Username of the user, with a maximum length of 100 characters
    password = models.CharField(max_length=100)  # Password of the user, stored as a plain text (note: consider using hashing for security)

    # String representation of the User object, which returns the username
    def __str__(self):
        return self.username



