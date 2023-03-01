import { useState } from "react";
import { MdContacts, MdLogin, MdLogout, MdMessage } from "react-icons/md";
import { useDispatch, useSelector } from "react-redux";
import { deauthenticateActionCreator } from "../../store/auth-slice";
import { NavLink } from "react-router-dom";
import classes from "./Header.module.css";
import AuthenticationModal from "../General/Overlays/Modals/AuthenticationModal";

function Header(props) {
  const { token } = useSelector((state) => state.auth);
  const { user } = useSelector((state) => state.user);

  const dispatch = useDispatch();
  const [isAuthenticationModalVisible, setIsAuthenticationModalVisible] =
    useState(false);

  const showAuthenticationModal = async (event) => {
    setIsAuthenticationModalVisible(true);
  };
  const hideAuthenticationModal = async (event) => {
    setIsAuthenticationModalVisible(false);
  };

  const signOutHandler = () => {
    dispatch(deauthenticateActionCreator());
  };

  return (
    <header className={classes["header"]}>
      <AuthenticationModal
        isVisible={isAuthenticationModalVisible}
        hide={hideAuthenticationModal}
      />
      <NavLink to="/" className={classes["logo"]} end>
        <h1>
          <MdContacts />
          Contacts
        </h1>
      </NavLink>

      {!token && (
        <button className={classes.button} onClick={showAuthenticationModal}>
          <MdLogin size={18} />
          SignIn
        </button>
      )}
      {token && user && (
        <button className={classes.button} onClick={signOutHandler}>
          <MdLogout size={18} />
          <p>SignOut - {user.email}</p>
        </button>
      )}
    </header>
  );
}

export default Header;
