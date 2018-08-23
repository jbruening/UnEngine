using System;

namespace UnityEngine.Assertions {
    public class AssertionException : Exception {
        private string m_UserMessage;

        public override string Message {
            get {
                string str = base.Message;
                if (this.m_UserMessage != null)
                    str = str + (object)'\n' + this.m_UserMessage;
                return str;
            }
        }

        public AssertionException(string message, string userMessage)
          : base(message) {
            this.m_UserMessage = userMessage;
        }
    }
}
