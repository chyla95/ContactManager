import { Md10K, MdPublic } from "react-icons/md";
import Contact from "./contact";
import styles from "./contacts.module.css";

const Contacts = (props) => {
  return (
    <div className={styles["contacts"]}>
      <h1>
        <MdPublic /> Public contacts
      </h1>
      {props.contacts.map((c) => (
        <Contact key={c.id} contact={c} />
      ))}
    </div>
  );
};

export default Contacts;
