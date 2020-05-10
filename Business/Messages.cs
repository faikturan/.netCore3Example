using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";

        public static string CategoryAdded = "Category başarıyla eklendi";
        public static string CategoryDeleted = "Category başarıyla silindi.";
        public static string CategoryUpdated = "Category başarıyla güncellendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Sisteme giriş başarılı.";
        public static string UserEmailExists = "Kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";
    }
}
