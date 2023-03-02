import Contact from "./Contact";
import styles from "./Contacts.module.css";

const Contacts = (props) => {
  return (
    <div className={styles["contacts"]}>
      {props.contacts.map((c) => (
        <Contact key={c.id} contact={c} isClickable={props.areClickable} />
      ))}
    </div>
  );
};

export default Contacts;
