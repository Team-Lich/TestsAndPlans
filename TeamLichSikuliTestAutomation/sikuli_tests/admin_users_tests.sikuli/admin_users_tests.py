import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class Users_Admin(unittest.TestCase):
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass
    
    def test_001_NavigateAndLogInAndLoginAdmin(self):
        adminUser = "TeamLichTestAdmin"
        adminPass = "123456"

        RunBrowserToUrl("chrome", "http://stage.telerikacademy.com/")
        LoginUser(adminUser, adminPass)
        wait(MainPage.button_adm, 30)
    
    def test_002_NavigateToAdminDashboard(self):
        NavigateToAdminDashboard()
        wait(AdminDashboard.title_admin, 30)

    def test_100_Logout(self):
        click(MainPage.button_logout)
        wait(MainPage.button_mainLogIn, 60)


if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(Users_Admin)

    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='Users Admin Report' )
    runner.run(suite)
    outfile.close()

