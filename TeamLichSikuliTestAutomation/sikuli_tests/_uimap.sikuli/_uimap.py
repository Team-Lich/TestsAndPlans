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

    registerLink = "registerImage.png"
    username = "usernameTextbox.png"
    password = "passwordTextbox.png"
    passwordAgain = "passwordAgainTextbox.png"
    firstName = "firstNameTextbox.png"
    lastName = "lastNameTextbox.png"
    email = "emailTextbox.png"
    registerButton = "registerButton.png"
    registrationCheckbox = "registerCheckbox"
    missingUsernameErrorText = "usernameMandatory"
    missingPasswordErrorText = "passwordMandatory"
    missingPasswordAgainErrorText = "passwordAgainMandatory"
    missingFirstNameErrorText = "firstNameMandatory"
    missingLastNameErrorText = "lastNameMandatory"
    missingEmailErrorText = "emailMandatory"
    usernameLengthErrorText = "usernameMinLengthErrorText"
    passwordLengthErrorText = "passwordLengthErrorText"
    firstNameIcorrectSymbols = "firstNameIcorrectSymbols"
    lastNameIcorrectSymbols = "lastNameIcorrectSymbols"
    unchceckedAgreements = "licenceAgreementMandatory"

    usernameLabel = "usernameLabel.png"
    passwordLabel = "passwordLabel.png"
    passwordAgainLabel = "passwordAgainLabel.png"
    firstNameLabel = "firstNameLabel.png"
    lastNameLabel = "lastNameLabel.png"
    emailLabel = "emailLabel.png"
    checkBoxLabel = "checkBoxLabel.png"

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
    header_roleName = "IIuenaponma.png"
    header_userCount = "Epoin0Tpe6me.png"
    test_008_expectedResult = "Epoin0Tpe6me-1.png"
    test_010_expectedResult = "1453457547150.png"
    button_deleteRow = Pattern("TestAdmin.png").targetOffset(253,-6)
    test_009_expectedResult = "Epoin0Tpe6me-2.png"
    test_011_expectedResult = "1453457977930.png"
    popup_comfirm = "1453458134946.png"
class Grid:
    button_add = "U06amme.png"
    button_update = "Ky.png"
    button_BackAdminDashboard = "KLMBAMIIHICT.png"
    button_downloadAsExel = "IQCsarmueH8E.png"
    button_exportAsExcel = "button_exportAsExcel.png"
    button_downloadAsPDF = "QCsammeH8PDF.png"
    button_edit = "1453318164265.png"
    button_sortingId = "button_sortingId.png"
    button_sortingUserName = "button_sortingUserName.png"
    button_sortingSN = "button_sortingSN.png"
    button_sortingName = "button_sortingName.png"
    button_sortingBD = "button_sortingBD.png"
    button_secondPage = Pattern("1453457502251.png").targetOffset(18,-1)
    button_goToLastPage = "1453457929773.png"
    result_sortingId = "result_sortingId.png"
    result_sortingUserName = "result_sortingUserName.png"
    result_sortingSN = "result_sortingSN.png"
    result_sortingBD = "result_sortingBD.png"
    result_firstSortingBD = Pattern("result_firstSortingBD.png").targetOffset(-54,43)
    result_secondSortingBD = Pattern("result_secondSortingBD.png").similar(0.53).targetOffset(-47,104)
    result_firstSortingId = Pattern("result_firstSortingId.png").targetOffset(-28,35)
    result_secondSortingId = Pattern("result_secondSortingId.png").targetOffset(-27,73)
    result_firstSortingName = Pattern("result_firstSortingName.png").targetOffset(-31,33)
    result_secondSortingName = Pattern("result_secondSortingName.png").targetOffset(-34,75)
    
class SaveAsBg:
    input_saveLocation = Pattern("3am1u1v1Kam.png").targetOffset(1,31)
    input_saveLocationEn = Pattern("input_saveLocationEn.png").targetOffset(96,-2)
    button_save = "1453315685007.png"
    button_saveEn = "button_saveEn.png"

class Windows:
    taskbar_chrome = "C.png"
    taskbar_chromium = "taskbar_chromium.png"


