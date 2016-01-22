from sikuli import *
import random, string
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

global randomUserName

def ScrollToVisible(maxScrolls,direction,goalImage): #direction =  "down" / "up"
    if(direction == "down"):
        direction = Key.PAGE_DOWN
    if(direction == "up"):
        direction = Key.PAGE_UP

    for i in range(maxScrolls):
        if not exists(goalImage):
            type(direction)
            if exists(MainPage.footer):
                direction = Key.PAGE_UP
        else:
            break

def RunBrowserToUrl(browser,toUrl):
    sleep(0.5)
    type("d",KEY_WIN); sleep(1)
    type("r", KEY_WIN); sleep(1)
    type(browser+" "); sleep(1)
    type(toUrl); sleep(1)
    type(Key.ENTER)

def RandomString():
   return ''.join(random.choice(string.lowercase) for i in range(10))

def RegisterRandomUser():
    click(AdminUsers.button_registerUser)
    wait(RegistrationPage.title_registration, 30)
    randomUserName = "TeamLichTestUser" + RandomString()
    type(RegistrationPage.input_username, randomUserName)
    type(RegistrationPage.input_password, "123456")
    type(RegistrationPage.input_passwordRepeat, "123456")
    type(Key.SHIFT, KeyModifier.ALT)
    type(RegistrationPage.input_firstName, "Zyl")
    ScrollToVisible(100, "down", RegistrationPage.input_lastName)
    type(RegistrationPage.input_lastName, "Nekromansyr")
    type(Key.SHIFT, KeyModifier.ALT)
    randomEmail = randomUserName + "@necropolis.heroes"
    type(RegistrationPage.input_email, randomEmail)
    click(RegistrationPage.chechbox_agreeWithTerms)
    click(RegistrationPage.button_register)

def LoginUser(username, password):
   #if not exists(MainPage.button_mainLogIn):
   #    click(MainPage.button_logout)

    wait(MainPage.button_mainLogIn, 40)
    click(MainPage.button_mainLogIn)
    wait(LoginPage.label_username, 20)
    click(LoginPage.label_username)
    type("a", Key.CTRL)
    paste(username)
    click(LoginPage.label_password)
    type("a", Key.CTRL)
    paste(password)
    click(LoginPage.button_logIn)

def NavigateToAdminDashboard():
    wait(MainPage.button_adm, 30)
    click(MainPage.button_adm)
    wait(AdminDashboard.title_admin, 30)

def NavigateToAdminUsers():
    wait(AdminDashboard.button_users, 30)
    click(AdminDashboard.button_users)
    wait(AdminUsers.title_users, 30)

def NavigateToFilteredExportToExcel():
    wait(AdminDashboard.button_filteredExportToExcel, 30)
    click(AdminDashboard.button_filteredExportToExcel)
    wait(AdminFilteredExportToExcel.title_filteredExportToExcel, 30)

def NavigateToRoles():
    wait(AdminDashboard.button_roles, 30)
    click(AdminDashboard.button_roles)
    wait(AdminUsersRoles.title_roles, 30)

def AddNewRole(roleName):
    wait(Grid.button_BackAdminDashboard, 30)
    click(Grid.button_add)
    click(AdminUsersRoles.label_roleName)
    type(roleName)
    click(Grid.button_update)

def DownloadAsEnglish(downloadType, location):  #DownloadType:  "Exel" "PDF"
    if(downloadType == "Exel"):
        downloadType = Grid.button_downloadAsExel
    if(downloadType == "PDF"):
        downloadType = Grid.button_downloadAsPDF
    if(downloadType == "Excel"):
        downloadType = Grid.button_exportAsExcel

    wait(downloadType, 30)
    click(downloadType)
    wait(SaveAsBg.button_saveEn, 30)
    click(SaveAsBg.input_saveLocationEn)
    type(location)
    wait(3)
    type(Key.ENTER)
    click(SaveAsBg.button_saveEn)

def DownloadAs(downloadType, location):  #DownloadType:  "Exel" "PDF"
    if(downloadType == "Exel"):
        downloadType = Grid.button_downloadAsExel
    if(downloadType == "PDF"):
        downloadType = Grid.button_downloadAsPDF
    if(downloadType == "Excel"):
        downloadType = Grid.button_exportAsExcel

    wait(downloadType, 30)
    click(downloadType)
    wait(SaveAsBg.button_save, 30)
    click(SaveAsBg.input_saveLocation)
    type(location)
    wait(1)
    type(Key.ENTER)
    click(SaveAsBg.button_save)

def CheckIfFileIsInDirectory(file, directory):
    type("r", KEY_WIN)
    wait(1)
    type(directory + Key.ENTER)
    wait(file, 30)
    click(Windows.taskbar_chrome)

def ChechIfFileIsInDirectoryChromium(file, directory):
    type("r", KEY_WIN)
    wait(1)
    type(directory + Key.ENTER)
    wait(file, 30)
    click(Windows.taskbar_chromium)

def RegisterUser(username, password, passwordAgain, firstName, lastName, email):
    type(RegistrationPage.usernameLabel, username); sleep(1)
    type(RegistrationPage.passwordLabel, password); sleep(1)
    type(RegistrationPage.passwordAgainLabel, passwordAgain); sleep(1)
    type(Key.SHIFT, KeyModifier.ALT)
    type(RegistrationPage.firstNameLabel, firstName); sleep(1)
    type(RegistrationPage.lastNameLabel, lastName); sleep(1)
    type(Key.SHIFT, KeyModifier.ALT)
    type(RegistrationPage.emailLabel, email); sleep(1)
    click(find(RegistrationPage.checkBoxLabel)); sleep(1)
    click(RegistrationPage.registerButton)

def Navigate(name):
    type("r", KeyModifier.WIN)
    type(name)
    type(Key.ENTER)
    sleep(2)
    type("http://stage.telerikacademy.com/")
    type(Key.ENTER)
    sleep(2)
    click(RegistrationPage.registerLink)
    sleep(1)