import styles from "./AuthenticationModal.module.css";
import Backdrop from "../Backdrop";
import { useState } from "react";
import SignInForm from "../../../Authentication/SignInForm";
import SignUpForm from "../../../Authentication/SignUpForm";

const AuthenticationModal = (props) => {
  const [action, setAction] = useState("SignIn");

  const changeAction = (actionType) => {
    setAction(actionType);
  };

  const finalizationHandler = () => {
    setAction("SignIn");
    props.hide();
  };

  const modal = (
    <Backdrop onClick={props.hide}>
      <div className={`${styles["modal"]}`}>
        {action === "SignIn" && (
          <SignInForm
            changeAction={changeAction}
            onSubmit={finalizationHandler}
          />
        )}
        {action === "SignUp" && (
          <SignUpForm
            changeAction={changeAction}
            onSubmit={finalizationHandler}
          />
        )}
      </div>
    </Backdrop>
  );

  return props.isVisible && modal;
};

export default AuthenticationModal;
