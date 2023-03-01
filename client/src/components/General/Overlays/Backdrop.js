import { createPortal } from "react-dom";
import styles from "./Backdrop.module.css";

const Backdrop = (props) => {
  const stopPropagation = (event) => {
    event.stopPropagation();
  };

  const backdrop = (
    <div className={`${styles["backdrop"]}`} onClick={props.onClick}>
      <div onClick={stopPropagation}>{props.children}</div>
    </div>
  );

  return createPortal(backdrop, document.getElementById("backdrop-root"));
};

export default Backdrop;
