import unittest

bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)

from _lib import *

class RegisterData:
    usernameCorrect = "someUser"
    passwordCorrect = "somepass"
    passwordAgainCorrect = passwordCorrect
    firstNameCorrect = 'firstname'
    lastNameCorrect = 'lastname'
    emailCorrect = "someEmail@mail.com"

class Registration(unittest.TestCase):
    def setUp(self):
        pass

    def tearDown(self):
        pass

    def test_001_RegisterUserWithMissingUsername(self):
        Navigate("chrome")
        RegisterUser("", RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect, RegisterData.firstNameCorrect,
                   RegisterData.lastNameCorrect, RegisterData.emailCorrect)
        assert exists(Registration.missingUsernameErrorText)

    def test_002_RegisterUserWithMissingPassword(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, "", "", RegisterData.firstNameCorrect,
                   RegisterData.lastNameCorrect, RegisterData.emailCorrect)
        assert exists(Registration.missingPasswordErrorText)

    def test_003_RegisterUserWithMissingFirstName(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect, "",
                   RegisterData.lastNameCorrect, RegisterData.emailCorrect)
        assert exists(Registration.missingFirstNameErrorText)

    def test_004_RegisterUserWithMissingLastName(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, "", RegisterData.emailCorrect)
        assert exists(Registration.missingLastNameErrorText)

    def test_005_RegisterUserWithMissingEmail(self):
        type('r', KeyModifier.CTRL); sleep(3)
        RegisterUser(RegisterData.usernameCorrect, RegisterData.passwordCorrect, RegisterData.passwordAgainCorrect,
                     RegisterData.firstNameCorrect, RegisterData.lastNameCorrect, "")
        assert exists(Registration.missingEmailErrorText)

if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(Registration)

    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='PaintTests Report')
    runner.run(suite)
    outfile.close()

