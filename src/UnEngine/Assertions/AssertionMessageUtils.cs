using System;

namespace UnityEngine.Assertions {
    internal class AssertionMessageUtil {
        private const string k_Expected = "Expected:";
        private const string k_AssertionFailed = "Assertion failure.";

        public static string GetMessage(string failureMessage) {
            return UnityString.Format("{0} {1}", (object)"Assertion failure.", (object)failureMessage);
        }

        public static string GetMessage(string failureMessage, string expected) {
            return AssertionMessageUtil.GetMessage(UnityString.Format("{0}{1}{2} {3}", (object)failureMessage, (object)Environment.NewLine, (object)"Expected:", (object)expected));
        }

        public static string GetEqualityMessage(object actual, object expected, bool expectEqual) {
            return AssertionMessageUtil.GetMessage(UnityString.Format("Values are {0}equal.", (object)(!expectEqual ? "" : "not ")), UnityString.Format("{0} {2} {1}", actual, expected, (object)(!expectEqual ? "!=" : "==")));
        }

        public static string NullFailureMessage(object value, bool expectNull) {
            return AssertionMessageUtil.GetMessage(UnityString.Format("Value was {0}Null", (object)(!expectNull ? "" : "not ")), UnityString.Format("Value was {0}Null", (object)(!expectNull ? "not " : "")));
        }

        public static string BooleanFailureMessage(bool expected) {
            return AssertionMessageUtil.GetMessage("Value was " + (object)!expected, expected.ToString());
        }
    }

}
