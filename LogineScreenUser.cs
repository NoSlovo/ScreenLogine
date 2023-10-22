using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LogineScreen
{
    public class LogineScreenUser : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _mail;
        [SerializeField] private TextMeshProUGUI _password;
        [SerializeField] private Button _buttonRegistration;
        [SerializeField] private FireBaseAthUser _athUser;

        private DataUserValidate _dataUserValidate = new DataUserValidate();

        private void OnEnable() => _buttonRegistration.onClick.AddListener(RegisterUser);

        private async void RegisterUser()
        {
            if (!_dataUserValidate.MailValidate(_mail.text))
                return;
            if (!_dataUserValidate.PasswordWalidate(_password.text))
                return;

            await Task.Run(() => { _athUser.RegisteUser(_mail.text, _password.text); });
        }

        private void OnDisable() => _buttonRegistration.onClick.AddListener(RegisterUser);
    }
}