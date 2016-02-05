﻿using Infrastructure.Identity.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            // Configurando validator para nome de usuario
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Logica de validação e complexidade de senha
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configuração de Lockout
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            //// Providers de Two Factor Autentication
            //RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "Seu código de segurança é: {0}"
            //});

            RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            // Definindo a classe de serviço de e-mail
            EmailService = new EmailService();

            //// Definindo a classe de serviço de SMS
            //SmsService = new SmsService();

            //var provider = new DpapiDataProtectionProvider("Guilherme");
            //var dataProtector = provider.Create("ASP.NET Identity");

            //UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector);

        }
    }
}
