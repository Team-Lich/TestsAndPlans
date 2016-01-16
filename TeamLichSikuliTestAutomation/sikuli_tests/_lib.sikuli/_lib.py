from sikuli import *
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

def RunBrowserToUrl(browser,toUrl):
    sleep(0.5)
    type("d",KEY_WIN); sleep(1)
    type("r", KEY_WIN); sleep(1)
    type(browser+" "); sleep(1)
    type(toUrl); sleep(1)
    type(Key.ENTER)

def LoginUser(username, password):
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