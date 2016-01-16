########################################################
# UI map for XYZ
########################################################
from sikuli import *
########################################################

class MainPage:
    button_mainLogIn = Pattern("button_mainLogIn.png").similar(0.92)
    button_adm = "button_adm.png"
    button_logout = Pattern("button_logout.png").similar(0.90)

class LoginPage:    
    label_username = Pattern("label_username.png").targetOffset(209,-9)
    label_password = Pattern("label_password.png").targetOffset(279,1)
    button_logIn = "button_logIn.png"

class AdminDashboard:
    title_admin = "title_admin.png"
    


