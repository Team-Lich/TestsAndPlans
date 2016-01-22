import unittest

bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)

from _lib import *

class RegisterData:
    usernameCorrect = "someUser1"
    passwordCorrect = "somepass"
    passwordAgainCorrect = passwordCorrect
    firstNameCorrect = 'firstname'
    lastNameCorrect = 'lastname'
    emailCorrect = "someEmail1@mail.com"
    usernameIncorrectMinimumLength = "ab"
    usernameIncorrectMaximumLength = 33 * "a"
    passwordIncorrectLength = "123"
    firstNameContainLatinSymbols = "abcd"
    lastNameContainLatinSymbols = "abcd"

class Registration(unittest.TestCase):
    def setUp(self):
        pass

    def tearDown(self):
        pass

    def test_001_RegisterUserWithMissingUsername(self):
        Navigate("chrome")
        RegisterUser("", RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect, RegisterData.firstNameCorrect,
                    RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.missingUsernameErrorText)

    def test_002_RegisterUserWithMissingPassword(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, "", "", RegisterData.firstNameCorrect,
                     RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.missingPasswordErrorText)

    def test_003_RegisterUserWithMissingPasswordAgain(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, "", RegisterData.firstNameCorrect,
                     RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.missingPasswordAgainErrorText)

    def test_004_RegisterUserWithMissingFirstName(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect, "",
                     RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.missingFirstNameErrorText)

    def test_005_RegisterUserWithMissingLastName(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, "", RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.missingLastNameErrorText)

    def test_006_RegisterUserWithMissingEmail(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, RegisterData.lastNameCorrect, "", True)
        assert exists(RegistrationPage.missingEmailErrorText)

    def test_007_RegisterUserWithIncorrectMinimumUsernameLength(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUserWithDoubleClick(RegisterData.usernameIncorrectMinimumLength, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.usernameLengthErrorText)

    def test_008_RegisterUserWithIncorrectMaximumUsernameLength(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUserWithDoubleClick(RegisterData.usernameIncorrectMaximumLength, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.usernameLengthErrorText)

    def test_009_RegisterUserWithIncorrectPasswordLength(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUserWithDoubleClick(RegisterData.usernameCorrect, RegisterData.passwordIncorrectLength, RegisterData.passwordIncorrectLength,
                     RegisterData.firstNameCorrect, RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.passwordLengthErrorText)

    def test_010_RegisterUserWithLatinSymbolsInFirstName(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUserWithoutChangeLanguage(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameContainLatinSymbols, RegisterData.lastNameCorrect, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.firstNameIcorrectSymbols)

    def test_011_RegisterUserWithLatinSymbolsInLastName(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUserWithoutChangeLanguage(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, RegisterData.lastNameContainLatinSymbols, RegisterData.emailCorrect, True)
        assert exists(RegistrationPage.lastNameIcorrectSymbols)

    def test_012_RegisterUserWithoutLicenceAgreement(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, RegisterData.lastNameCorrect, RegisterData.emailCorrect, False)
        assert exists(RegistrationPage.unchceckedAgreements)

if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(Registration)

    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='PaintTests Report')
    runner.run(suite)
    outfile.close()

