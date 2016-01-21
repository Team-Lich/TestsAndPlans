import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *
    
class Users_Admin(unittest.TestCase):
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass
    
    # def test_001_NavigateAndLogInAndLoginAdmin(self):
    #     adminUser = "TeamLichTestAdmin"
    #     adminPass = "123456"
    #
    #     RunBrowserToUrl("chrome", "http://stage.telerikacademy.com/")
    #     LoginUser(adminUser, adminPass)
    #     wait(MainPage.button_adm, 30)
    #
    # def test_002_NavigateToAdminDashboard(self):
    #     NavigateToAdminDashboard()
    #     wait(AdminDashboard.title_admin, 30)
        
    #START - Tests Dimitar - 21.01.16
    
    # def test_0021_NavigateToAdminUsers(self):
    #     NavigateToAdminDashboard()
    #     ScrollToVisible(100, "down", AdminDashboard.button_users)
    #     NavigateToAdminUsers()

    # def test_0022_RegisterNewUser(self):
    #     RegisterRandomUser()

    # def test_0023_ExportUsersAsExcel(self):
    #     location = "C:\Users\Dimitar Panayotov\Desktop\ForTest"  #change this to whatever feels good in order to work for you
    #     DownloadAsEnglish("Excel", location)
    #     ChechIfFileIsInDirectoryChromium(AdminUsers.file_excel,location)

    # def test_0023_AdminUsers_BackToAdmin(self):
    #     click(Grid.button_BackAdminDashboard)

    # def test_0023_AdminUsers_SortingId(self):
    #     click(Grid.button_sortingId)
    #     wait(Grid.result_sortingId)
    #     exists(Grid.result_sortingId)

    def test_0023_AdminUsers_SortingUserName(self):
        click(Grid.button_sortingUserName)
        wait(Grid.result_sortingUserName)
        exists(Grid.result_sortingUserName)

    # def test_0023_FilterByCriteriaID(self):
    #     click(AdminUsers.button_filterByCriteria)
    #     click(AdminUsers.dropDown_pickACriteria)
    #     click(AdminUsers.dropDown_criteriaId)
    #     type(AdminUsers.textbox_criteriaValues, "189")
    #     click(AdminUsers.button_extract)
    #     exists(AdminUsers.result_criteriaId)

    # def test_0024_FilterByCriteriaName(self):
    #     click(AdminUsers.button_filterByCriteria)
    #     click(AdminUsers.dropDown_pickACriteria)
    #     click(AdminUsers.dropDown_criteriaName)
    #     #type(AdminUsers.textbox_criteriaValues, randomUserName)
    #     type(AdminUsers.textbox_criteriaValues, "TeamLichTestUser")
    #     click(AdminUsers.button_extract)
    #     exists(AdminUsers.result_criteriaId)
    #
    # def test_002_FilterByCriteriaEmail(self):
    #     click(AdminUsers.button_filterByCriteria)
    #     click(AdminUsers.dropDown_pickACriteria)
    #     click(AdminUsers.dropDown_criteriaEmail)
    #     type(AdminUsers.textbox_criteriaValues, "mausoleum@necropolis.heroes")
    #     click(AdminUsers.button_extract)
    #     exists(AdminUsers.result_criteriaId)
    #
    # def test_009991_NavigateToFilteredExportToExcel(self):
    #     NavigateToAdminDashboard()
    #     ScrollToVisible(100, "down", AdminDashboard.button_filteredExportToExcel)
    #     NavigateToFilteredExportToExcel()
    #
    # #END - Tests Dimitar - 21.01.16
    #
    # def test_003_NavigateToRoles(self):
    #     ScrollToVisible(100, "down", AdminDashboard.button_roles)
    #     NavigateToRoles()
    #     wait(AdminUsersRoles.title_roles, 30)
    #
    # def test_004_AddNewRole(self):
    #     AddNewRole("TestAdmin")
    #     wait(AdminUsersRoles.test_004_expectedResult, 30)
    #
    # def test_005_SaveAsExel(self):
    #     location = "C:\Users\ivan\Desktop\ForTest"  #change this to whatever feels good in order to work for you
    #     DownloadAs("Exel", location)
    #     CheckIfFileIsInDirectory(AdminUsersRoles.test_005_exelFile,location)
    #
    # def test_006_SaveAsPDF(self):
    #     location = "C:\Users\ivan\Desktop\ForTest"  #change this to whatever feels good in order to work for you
    #     DownloadAs("PDF", location)
    #     CheckIfFileIsInDirectory(AdminUsersRoles.test_006_pdfFile,location)
    #
    # def test_007_Edit(self):
    #     AddNewRole("TestAdmin")
    #     find(AdminUsersRoles.test_004_expectedResult).highlight(1).right().highlight(1).click(Grid.button_edit)
    #     wait(Grid.button_update, 30)
    #     doubleClick(AdminUsersRoles.label_roleName)
    #     type("asd")
    #     click(Grid.button_update)
    #     wait(AdminUsersRoles.test_007_expedtedResult, 30)
    #
    # def test_008_DragColumnHeader(self):
    #     pass
    # def test_009_DeleteRow(self):
    #     pass
    # def test_010_Paging(self):
    #     pass
    # def test_011_GoToLastPage(self):
    #     pass
    # def test_012_Sort(self):
    #     pass
    #
    # def test_013_BackToAdministration(self):
    #     wait(Grid.button_BackAdminDashboard, 30)
    #     click(Grid.button_BackAdminDashboard)
    #     wait(AdminDashboard.title_admin, 30)
    #
    # def test_100_Logout(self):
    #    click(MainPage.button_logout)
    #    wait(MainPage.button_mainLogIn, 60)


if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(Users_Admin)

    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='Users Admin Report' )
    runner.run(suite)
    outfile.close()

