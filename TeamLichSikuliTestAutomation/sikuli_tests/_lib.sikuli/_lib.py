from sikuli import *
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

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

def DownloadAs(downloadType, location):  #DownloadType:  "Exel" "PDF"
    if(downloadType == "Exel"):
        downloadType = Grid.button_downloadAsExel
    if(downloadType == "PDF"):
        downloadType = Grid.button_downloadAsPDF

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
    type(directory + Key.ENTER)
    wait(file, 30)
    click(Windows.taskbar_chrome)

