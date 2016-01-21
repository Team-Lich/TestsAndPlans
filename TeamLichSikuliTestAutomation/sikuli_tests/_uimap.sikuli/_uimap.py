########################################################
# UI map for XYZ
########################################################
from sikuli import *
########################################################

class MainPage:
    button_mainLogIn = Pattern("button_mainLogIn.png").similar(0.92)
    button_adm = "button_adm.png"
    button_logout = Pattern("button_logout.png").similar(0.90)
    footer = "1453311612551.png"

class LoginPage:    
    label_username = Pattern("label_username.png").targetOffset(209,-9)
    label_password = Pattern("label_password.png").targetOffset(279,1)
    button_logIn = "button_logIn.png"

class AdminDashboard:
    title_admin = "title_admin.png"
    button_roles = "Pcnvn.png"
    button_filteredExportToExcel = "button_filteredExportToExcel.png"
    button_users = "button_users.png"

class AdminUsers:
    title_users = "title_users.png"
    button_filterByCriteria = "button_filterByCriteria.png"
    dropDown_pickACriteria = Pattern("dropDown_pickACriteria.png").targetOffset(125,-2)
    dropDown_criteriaId = Pattern("dropDown_criteriaId.png").targetOffset(-8,51)
    dropDown_criteriaName = Pattern("dropDown_criteriaName.png").targetOffset(-1,73)
    dropDown_criteriaEmail = Pattern("dropDown_criteriaEmail.png").targetOffset(-9,110)
    textbox_criteriaValues = "textbox_criteriaValues.png"
    button_extract = "button_extract.png"
    result_criteriaId = "result_criteriaId.png"
    button_registerUser = "button_registerUser.png"
    file_excel = "file_excel.png"

class RegistrationPage:
    input_username = "input_username.png"
    input_password = "input_password.png"
    input_passwordRepeat = "input_passwordRepeat.png"
    input_firstName = "input_firstName.png"
    input_lastName = "input_lastName.png"
    input_email = "input_email.png"
    chechbox_agreeWithTerms = "chechbox_agreeWithTerms.png"
    button_register = "button_register.png"
    title_registration = "title_registration.png"

class AdminFilteredExportToExcel:
    title_filteredExportToExcel = "title_filteredExportToExcel.png"
    dropDown_pickCriteria = "dropDown_pickCriteria.png"
    dropDown_byId = "dropDown_byId.png"
    dropDown_byName = "dropDown_byName.png"
    dropdown_byEmail = "dropdown_byEmail.png"
    textbox_enterCriterias = "textbox_enterCriterias.png"
    button_extract = "button_extract.png"
class AdminUsersRoles:
    title_roles = "IIOTp6lITEIC.png"
    label_roleName = Pattern("Mmenaponma.png").targetOffset(186,-2)
    test_004_expectedResult = "IIuenaponmaT.png"
    test_005_exelFile = "R0es_Exp0rt.png"
    test_006_pdfFile = "ER0es_Exp0rt-1.png"
    test_007_expedtedResult = "IIuenaponmaa.png"

class Grid:
    button_add = "U06amme.png"
    button_update = "Ky.png"
    button_BackAdminDashboard = "KLMBAMIIHICT.png"
    button_downloadAsExel = "IQCsarmueH8E.png"
    button_exportAsExcel = "button_exportAsExcel.png"
    button_downloadAsPDF = "QCsammeH8PDF.png"
    button_edit = "1453318164265.png"

class SaveAsBg:
    input_saveLocation = Pattern("3am1u1v1Kam.png").targetOffset(1,31)
    input_saveLocationEn = Pattern("input_saveLocationEn.png").targetOffset(96,-2)
    button_save = "1453315685007.png"
    button_saveEn = "button_saveEn.png"

class Windows:
    taskbar_chrome = "C.png"
    


