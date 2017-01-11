namespace Args.Properties
{
    using System;
    using System.Collections.Generic;

    internal class Resources
    {
        internal class ResourceManager
        {
            private static string AddMethodNotFoundMessage = "Type {0} does not contain a method named 'Add'.";
            private static string ArgsMissingValue = "Missing a value after {0}";
            private static string BoolWithDefaultInModel = "Booleans with a default value are not meaningful.If the switch exists, the value is true, otherwise the value is false.";
            private static string IncorrectNumberOfOrdinalArgumentsMessage = "Number of ordinal arguments must at least {0}.";
            private static string InvalidMemberName = "Can not derive short name for member {0} in type {1}. Most likely another member name starts with '{0}'.";
            private static string MemberNotFoundInAvailableMembers = "Can not derive short name for member {0} in type {1}. It is not in the list of possible members to pick from.";
            private static string NullableBoolInModel = "Nullable boolean values can not be bound in a meaningful way, please consider using Boolean or an Enum.";
            private static string OnlyLastOridnalArgumentCollectionMessage = "Only the last oridinal argument can implement IEnumerable&lt;&gt; (except System.String).";
            private static string RequiredParameterNotProvidedMessage = "'{0}' is a required parameter.";
            private static string TypeConverterNotFoundMessage = "Cannot find appropriate type converter from type {0} to type {1}.";

            private static Dictionary<string, string> _resources = new Dictionary<string, string>();

            static ResourceManager()
            {
                _resources = new Dictionary<string, string>
                {
                    { "AddMethodNotFoundMessage", AddMethodNotFoundMessage },
                    { "ArgsMissingValue", ArgsMissingValue },
                    { "BoolWithDefaultInModel", BoolWithDefaultInModel },
                    { "IncorrectNumberOfOrdinalArgumentsMessage", IncorrectNumberOfOrdinalArgumentsMessage },
                    { "InvalidMemberName", InvalidMemberName },
                    { "MemberNotFoundInAvailableMembers", MemberNotFoundInAvailableMembers },
                    { "NullableBoolInModel", NullableBoolInModel },
                    { "OnlyLastOridnalArgumentCollectionMessage", OnlyLastOridnalArgumentCollectionMessage },
                    { "RequiredParameterNotProvidedMessage", RequiredParameterNotProvidedMessage },
                    { "TypeConverterNotFoundMessage", TypeConverterNotFoundMessage },
                };
            }

            internal static string GetString(string name, string culture)
            {
                return _resources[name];
            }
        }

        private static string resourceCulture;
        

        /// <summary>
        ///   Looks up a localized string similar to Type {0} does not contain a method named &apos;Add&apos;..
        /// </summary>
        internal static string AddMethodNotFoundMessage
        {
            get
            {
                return ResourceManager.GetString("AddMethodNotFoundMessage", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Missing a value after {0}.
        /// </summary>
        internal static string ArgsMissingValue
        {
            get
            {
                return ResourceManager.GetString("ArgsMissingValue", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Booleans with a default value are not meaningful.  If the switch exists, the value is true, otherwise the value is false..
        /// </summary>
        internal static string BoolWithDefaultInModel
        {
            get
            {
                return ResourceManager.GetString("BoolWithDefaultInModel", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Number of ordinal arguments must at least {0}..
        /// </summary>
        internal static string IncorrectNumberOfOrdinalArgumentsMessage
        {
            get
            {
                return ResourceManager.GetString("IncorrectNumberOfOrdinalArgumentsMessage", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Can not derive short name for member {0} in type {1}. Most likely another member name starts with &apos;{0}&apos;..
        /// </summary>
        internal static string InvalidMemberName
        {
            get
            {
                return ResourceManager.GetString("InvalidMemberName", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Can not derive short name for member {0} in type {1}. It is not in the list of possible members to pick from..
        /// </summary>
        internal static string MemberNotFoundInAvailableMembers
        {
            get
            {
                return ResourceManager.GetString("MemberNotFoundInAvailableMembers", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Nullable boolean values can not be bound in a meaningful way, please consider using Boolean or an Enum..
        /// </summary>
        internal static string NullableBoolInModel
        {
            get
            {
                return ResourceManager.GetString("NullableBoolInModel", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Only the last oridinal argument can implement IEnumerable&lt;&gt; (except System.String)..
        /// </summary>
        internal static string OnlyLastOridnalArgumentCollectionMessage
        {
            get
            {
                return ResourceManager.GetString("OnlyLastOridnalArgumentCollectionMessage", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; is a required parameter..
        /// </summary>
        internal static string RequiredParameterNotProvidedMessage
        {
            get
            {
                return ResourceManager.GetString("RequiredParameterNotProvidedMessage", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Cannot find appropriate type converter from type {0} to type {1}..
        /// </summary>
        internal static string TypeConverterNotFoundMessage
        {
            get
            {
                return ResourceManager.GetString("TypeConverterNotFoundMessage", resourceCulture);
            }
        }
    }
}