using System;
using System.IO;

namespace QuanLyCF.DAL
{
    public static class Config
    {
        public static readonly string UserImagePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\User\"));
    }
}

