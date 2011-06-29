﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace EntityFramework.Search.Data
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class WatercoolerEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new WatercoolerEntities object using the connection string found in the 'WatercoolerEntities' section of the application configuration file.
        /// </summary>
        public WatercoolerEntities() : base("name=WatercoolerEntities", "WatercoolerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new WatercoolerEntities object.
        /// </summary>
        public WatercoolerEntities(string connectionString) : base(connectionString, "WatercoolerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new WatercoolerEntities object.
        /// </summary>
        public WatercoolerEntities(EntityConnection connection) : base(connection, "WatercoolerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="WatercoolerModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="firstname">Initial value of the Firstname property.</param>
        /// <param name="lastname">Initial value of the Lastname property.</param>
        /// <param name="email">Initial value of the Email property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        /// <param name="enabled">Initial value of the Enabled property.</param>
        /// <param name="rowVersion">Initial value of the RowVersion property.</param>
        public static User CreateUser(global::System.Guid userId, global::System.String firstname, global::System.String lastname, global::System.String email, global::System.String password, global::System.Boolean enabled, global::System.Byte[] rowVersion)
        {
            User user = new User();
            user.UserId = userId;
            user.Firstname = firstname;
            user.Lastname = lastname;
            user.Email = email;
            user.Password = password;
            user.Enabled = enabled;
            user.RowVersion = rowVersion;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    OnUserIdChanging(value);
                    ReportPropertyChanging("UserId");
                    _UserId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                OnFirstnameChanging(value);
                ReportPropertyChanging("Firstname");
                _Firstname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Firstname");
                OnFirstnameChanged();
            }
        }
        private global::System.String _Firstname;
        partial void OnFirstnameChanging(global::System.String value);
        partial void OnFirstnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Lastname
        {
            get
            {
                return _Lastname;
            }
            set
            {
                OnLastnameChanging(value);
                ReportPropertyChanging("Lastname");
                _Lastname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Lastname");
                OnLastnameChanged();
            }
        }
        private global::System.String _Lastname;
        partial void OnLastnameChanging(global::System.String value);
        partial void OnLastnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                OnEnabledChanging(value);
                ReportPropertyChanging("Enabled");
                _Enabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Enabled");
                OnEnabledChanged();
            }
        }
        private global::System.Boolean _Enabled;
        partial void OnEnabledChanging(global::System.Boolean value);
        partial void OnEnabledChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte[] RowVersion
        {
            get
            {
                return StructuralObject.GetValidValue(_RowVersion);
            }
            set
            {
                OnRowVersionChanging(value);
                ReportPropertyChanging("RowVersion");
                _RowVersion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("RowVersion");
                OnRowVersionChanged();
            }
        }
        private global::System.Byte[] _RowVersion;
        partial void OnRowVersionChanging(global::System.Byte[] value);
        partial void OnRowVersionChanged();

        #endregion
    
    }

    #endregion
    
}
