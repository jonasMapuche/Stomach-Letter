namespace Letter.Helpers
{
    public static class FilePath
    {

        #region ERROR
        private static bool _error_on = true;
        private static bool _error_off = false;
        private static string? _error_message;

        public static string? error_message
        {
            get => _error_message;
            set
            {
                _error_message = value;
            }
        }

        public static event EventHandler<string>? OnError;
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        #endregion

        #region FUNCTION
        public static string MountFileName(string extension)
        {
            try
            {
                if (_error_off) throw new InvalidOperationException("Operation file name \"File Path\" helper failed!!");

                string file_name = string.Empty;
                if (extension == "mp4")
                    file_name = "/Record_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".mp4";
                if (extension == "jpeg")
                    file_name = "/Image_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".jpeg";
                if (extension == "mp3")
                    file_name = "/Record_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".mp3";
                if (extension == "wav")
                    file_name = "/Record_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".wav";
                if (extension == "txt")
                    file_name = "/Text_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".txt";
                return file_name;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                throw new InvalidOperationException(error_message);
            }
        }

        public static string SetAudioFilePath(string file_name)
        {
            try
            {
                if (_error_off) throw new InvalidOperationException("Operation audio file path \"File Path\" helper failed!!");

                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                string file_path = path + file_name;
                Directory.CreateDirectory(file_path);
                return file_path;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                throw new InvalidOperationException(error_message);
            }
        }

        public static string MountPath()
        {
            try
            {
                if (_error_off) throw new InvalidOperationException("Operation audio file path \"File Path\" helper failed!!");

                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                Directory.CreateDirectory(path);
                return path;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                throw new InvalidOperationException(error_message);
            }
        }

        public static string MountFilePath(string file_name)
        {
            try
            {
                if (_error_off) throw new InvalidOperationException("Operation audio file path \"File Path\" helper failed!!");

                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string file_path = path + file_name;
                return file_path;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                throw new InvalidOperationException(error_message);
            }
        }
        #endregion
    }
}
