import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *
import xmlrunner
    
class Users_Admin(unittest.TestCase):
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass

#Start - Tests Ivan - 21.01.16

    def test_001_NavigateAndLogInAndLoginAdmin(self):
        adminUser = "TeamLichTestAdmin"
        adminPass = "123456"

        RunBrowserToUrl("chrome", "http://stage.telerikacademy.com/")
        LoginUser(adminUser, adminPass)
        actual = exists(MainPage.button_adm, 30)
        self.assertTrue(actual)

    def test_002_NavigateToAdminDashboard(self):
        NavigateToAdminDashboard()
        actual = exists(AdminDashboard.title_admin, 30)
        self.assertTrue(actual)

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
    #     find(AdminUsersRoles.test_004_expectedResult).right().click(Grid.button_edit)
    #     wait(Grid.button_update, 30)
    #     doubleClick(AdminUsersRoles.label_roleName)
    #     type("asd")
    #     click(Grid.button_update)
    #     wait(AdminUsersRoles.test_007_expedtedResult, 30)
    #
    # def test_008_DragColumnHeader(self):
    #     wait(AdminUsersRoles.header_roleName, 30)
    #     dragDrop(AdminUsersRoles.header_roleName, AdminUsersRoles.header_userCount)
    #     wait(AdminUsersRoles.test_008_expectedResult)
    #
    # def test_009_DeleteRow(self):
    #     AddNewRole("TestAdmin")
    #     click(AdminUsersRoles.button_deleteRow)
    #     wait(AdminUsersRoles.popup_comfirm, 30)
    #     click(AdminUsersRoles.popup_comfirm)
    #     wait(AdminUsersRoles.test_009_expectedResult)
    #
    # def test_010_Paging(self):
    #     ScrollToVisible(100, "down", Grid.button_secondPage)
    #     click(Grid.button_secondPage)
    #     wait(AdminUsersRoles.test_010_expectedResult, 30)
    #
    # def test_011_GoToLastPage(self):
    #     RunBrowserToUrl("chrome", "http://stage.telerikacademy.com/Administration_Users/Roles")
    #     ScrollToVisible(100, "down", Grid.button_goToLastPage)
    #     click(Grid.button_goToLastPage)
    #     wait(AdminUsersRoles.test_011_expectedResult, 30)
    #
    # def test_012_Sort(self):
    #     pass
    #
    # def test_013_BackToAdministration(self):
    #      ScrollToVisible(100, "up", Grid.button_BackAdminDashboard)
    #      click(Grid.button_BackAdminDashboard)
    #      wait(AdminDashboard.title_admin, 30)

#END - Tests Ivan - 21.01.16

# START - Tests Dimitar - 21.01.16

  #  def test_014_AdminUsers_NavigateToAdminUsers(self):
  #      NavigateToAdminDashboard()
  #      ScrollToVisible(100, "down", AdminDashboard.button_users)
  #      NavigateToAdminUsers()
  #
  #  def test_015_AdminUsers_RegisterNewUser(self):
  #      RegisterRandomUser()
  #
  #  def test_016_ExportUsersAsExcel(self):
  #      location = "C:\Users\Dimitar Panayotov\Desktop\ForTest"  #change this to whatever feels good in order to work for you
  #      DownloadAsEnglish("Excel", location)
  #      ChechIfFileIsInDirectoryChromium(AdminUsers.file_excel,location)
  #
  #  def test_016_AdminUsers_BackToAdmin(self):
  #      NavigateToAdminDashboard()
  #      ScrollToVisible(100, "down", AdminDashboard.button_users)
  #      NavigateToAdminUsers()
  #      wait(Grid.button_BackAdminDashboard, 20)
  #      click(Grid.button_BackAdminDashboard)
  #
  #  def test_017_AdminUsers_SortingId(self):
  #      ScrollToVisible(100, "down", AdminDashboard.button_users)
  #      NavigateToAdminUsers()
  #      wait(Grid.button_sortingUserName, 30)
  #      click(Grid.button_sortingUserName)
  #      click(Grid.button_sortingId)
  #      wait(2)
  #      doubleClick(Grid.result_firstSortingId)
  #      type("c", KEY_CTRL)
  #      resultOne = Env.getClipboard()
  #      hover(Grid.button_sortingId)
  #      doubleClick(Grid.result_secondSortingId)
  #      type("c", KEY_CTRL)
  #      resultTwo = Env.getClipboard()
  #      actualResult= resultOne < resultTwo
  #      expectedResult = True
  #      self.assertEqual(actualResult, expectedResult)
  #      self.assertEqual(resultOne, "1")
  #
  #  def test_018_AdminUsers_SortingUserName(self):
  #      click(Grid.button_sortingUserName)
  #      wait(2)
  #      doubleClick(Grid.result_firstSortingUserName)
  #      type("c", KEY_CTRL)
  #      resultOne = Env.getClipboard()
  #      hover(Grid.button_sortingId)
  #      doubleClick(Grid.result_secondSortingUserName)
  #      type("c", KEY_CTRL)
  #      resultTwo = Env.getClipboard()
  #      actualResult= resultOne >= resultTwo
  #      expectedResult = True
  #      self.assertEqual(actualResult, expectedResult)
  #
  #  def test_019_AdminUsers_SortingSN(self):
  #      click(Grid.button_sortingSN)
  #      doubleClick(Grid.result_firstSortingBD)
  #      type("c", KEY_CTRL)
  #      resultOne = Env.getClipboard()
  #      hover(Grid.button_sortingSN)
  #      doubleClick(Grid.result_secondSortingBD)
  #      type("c", KEY_CTRL)
  #      resultTwo = Env.getClipboard()
  #      actualResult= resultOne < resultTwo
  #      expectedResult = True
  #      self.assertEqual(actualResult, expectedResult)
  #
  #  def test_020_AdminUsers_SortingName(self):
  #      click(Grid.button_sortingName) #Here the test fails since when clicked (even in a manual test) the button does nothing
  #      doubleClick(Grid.result_firstSortingName)
  #      type("c", KEY_CTRL)
  #      resultOne = Env.getClipboard()
  #      hover(Grid.button_sortingName)
  #      doubleClick(Grid.result_secondSortingName)
  #      type("c", KEY_CTRL)
  #      resultTwo = Env.getClipboard()
  #      actualResult= resultOne < resultTwo
  #      expectedResult = True
  #      self.assertEqual(actualResult, expectedResult)
  #
  #  def test_021_AdminFilterByCriteria_ExportByID(self):
  #      NavigateToAdminDashboard()
  #      ScrollToVisible(100, "down", AdminDashboard.button_users)
  #      NavigateToAdminUsers()
  #      wait(AdminUsers.button_filterByCriteria, 30)
  #      click(AdminUsers.button_filterByCriteria)
  #      click(AdminUsers.dropDown_pickACriteria)
  #      click(AdminUsers.dropDown_criteriaId)
  #      type(AdminUsers.textbox_criteriaValues, "189")
  #      click(AdminUsers.button_extract)
  #      exists(AdminUsers.result_criteriaId)
  #
  #  def test_022_AdminFilterByCriteria_ExportByName(self):
  #      NavigateToAdminDashboard()
  #      ScrollToVisible(100, "down", AdminDashboard.button_users)
  #      NavigateToAdminUsers()
  #      wait(AdminUsers.button_filterByCriteria, 30)
  #      click(AdminUsers.button_filterByCriteria)
  #      click(AdminUsers.dropDown_pickACriteria)
  #      click(AdminUsers.dropDown_criteriaName)
  #      #type(AdminUsers.textbox_criteriaValues, randomUserName)
  #      type(AdminUsers.textbox_criteriaValues, "TeamLichTestUser")
  #      click(AdminUsers.button_extract)
  #      exists(AdminUsers.result_criteriaId)
  #
  #  def test_023_AdminFilterByCriteria_ExportByEmail(self):
  #      NavigateToAdminDashboard()
  #      ScrollToVisible(100, "down", AdminDashboard.button_users)
  #      NavigateToAdminUsers()
  #      wait(AdminUsers.button_filterByCriteria, 30)
  #      click(AdminUsers.button_filterByCriteria); sleep(1)
  #      click(AdminUsers.dropDown_pickACriteria)
  #      wait(2)
  #      click(AdminUsers.dropDown_criteriaEmail)
  #      type(AdminUsers.textbox_criteriaValues, "mausoleum@necropolis.heroes")
  #      click(AdminUsers.button_extract)
  #      exists(AdminUsers.result_criteriaId)
  #
  #  def test_024_NavigateToFilteredExportToExcel(self):
  #      NavigateToAdminDashboard()
  #      ScrollToVisible(100, "down", AdminDashboard.button_filteredExportToExcel)
  #      NavigateToFilteredExportToExcel()
  #
    # END - Tests Dimitar - 21.01.16
	#
	# START - Tests Decho - 22.01.16

  #  def test_025_NavigateToCities(self):
  #      NavigateToAdminDashboard()
  #      sleep(5)
  #      ScrollToVisible(10, "down", AdminDashboard.button_areas)
  #      click(AdminDashboard.button_areas)
  #      wait(AdminUsersCities.image_header, 10)
  #
  #  def test_026_AreaNameInEnglishDoesNotAcceptNonLatinSymbols(self):
  #      newAreaNameInEnglish = "Nekropolis"
  #      click(Grid.button_add)
  #      wait(AdminUsersCities.label_addPopupNameBG)
  #      type(Key.SHIFT, KeyModifier.ALT); sleep(1)
  #      type(AdminUsersCities.label_addPopupNameEN, newAreaNameInEnglish)
  #      type(AdminUsersCities.label_addPopupNameBG, newAreaNameInEnglish)
  #      click(Grid.button_update)
  #      warningShown = exists(Grid.field_cyrilicSymbolWarning)
  #      self.assertTrue(warningShown)
  #
  #  def test_027_AreaNameInBulgarianDoesNotAcceptLatinSymbols(self):
  #      newAreaNameInEnglish = "Nekropolis"
  #      wait(AdminUsersCities.label_addPopupNameBG)
  #      type(Key.SHIFT, KeyModifier.ALT); sleep(1)
  #      doubleClick(AdminUsersCities.label_addPopupNameEN)
  #      type(newAreaNameInEnglish)
  #      doubleClick(AdminUsersCities.label_addPopupNameBG)
  #      type(newAreaNameInEnglish)
  #      click(Grid.button_update)
  #      warningShown = exists(Grid.field_latinSymbolWarning)
  #      self.assertTrue(warningShown)
  #
  #  def test_028_AddNewArea(self):
  #      newAreaName = "Nekropolis"
  #      wait(AdminUsersCities.label_addPopupNameBG)
  #      type(Key.SHIFT, KeyModifier.ALT); sleep(1)
  #      doubleClick(AdminUsersCities.label_addPopupNameBG)
  #      type(newAreaName)
  #      type(Key.SHIFT, KeyModifier.ALT); sleep(1)
  #      doubleClick(AdminUsersCities.label_addPopupNameEN)
  #      type(newAreaName)
  #      click(Grid.button_update)
  #      wait(AdminUsersCities.label_nameOfNewlyAddedArea, 5)
  #
  #  def test_029_RemoveArea(self):
  #      DeleteRow(AdminUsersCities.label_nameOfNewlyAddedArea)
  #      areaStillInGrid = exists(AdminUsersCities.label_nameOfNewlyAddedArea, 5)
  #      self.assertIsNone(areaStillInGrid)
	
	#END - Tests Decho - 22.01.16

    def test_100_Logout(self):
        wait(MainPage.button_logout)
        click(MainPage.button_logout)

        actual = exists(MainPage.button_mainLogIn, 60)
        self.assertTrue(actual)


if __name__ == '__main__':
 #   suite = unittest.TestLoader().loadTestsFromTestCase(Users_Admin)
 #
 #   outfile = open("report.html", "w")
 #   runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='Users Admin Report' )
 #   runner.run(suite)
	
 	suite = unittest.TestLoader().loadTestsFromTestCase(Users_Admin)
	result = xmlrunner.XMLTestRunner(file("unittest.xml", "w")).run(suite)

  #  outfile.close()

