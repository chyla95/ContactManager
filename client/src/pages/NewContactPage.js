import { useLoaderData } from "react-router-dom";
import ContactForm from "../components/contacts/ContactForm";
import { getCategories } from "../services/category";
import store from "../store/store";
import styles from "./ContactDetailsPage.module.css";

const NewContactPage = (props) => {
  const { categories } = useLoaderData();

  return (
    <div className={styles["page-root"]}>
      <ContactForm mode="CREATE" categories={categories} />
    </div>
  );
};
export default NewContactPage;

export const newContactPageLoader = async () => {
  const { auth } = store.getState();
  if (!auth.token) return null;

  const categories = await getCategories(auth.token);
  return { categories };
};
