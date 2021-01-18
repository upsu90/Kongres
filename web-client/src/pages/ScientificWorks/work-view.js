import React, { useEffect } from "react";
import "../../App.css";
import { makeStyles } from "@material-ui/core/styles";
import { useLocation } from "react-router-dom";
import Information from "../../components/ScientificWork/Information";
import VersionPanel from "../../components/ScientificWork/VersionPanel";
import axios from "axios";
import { URL_API } from "../../Constants";
import defaultPhoto from "../../images/empty-image.png";

export default function WorkView() {
  const style = makeStyles({
    path: {
      width: "70%",
      padding: "2%",
      paddingLeft: "10%",
      float: "left",
      textAlign: "left",
      color: "grey",
      fontSize: "14px",
    },
    title: {
      fontWeight: "bold",
    },
    menu: {
      paddingTop: "800px",
    },
  })();

  const location = useLocation();

  const [workPDF, SetWorkPDF] = React.useState(null);
  const [data, setData] = React.useState({
    scientificWork: "",
    mainAuthor: "",
    versions: [],
    status: "",
    mode: "",
  });

  useEffect(() => {
    let id = window.location.pathname.split("/").slice(-1)[0];
    if (isNaN(id)) id = null;
    console.log(location.state?.detail ? location.state?.detail : id);

    const token = localStorage.getItem("jwt");

    // get scientific work file
    (async () => {
      await axios
        .get(`${URL_API}/ScientificWork/Download/${Number(id)}`, {
          headers: { Authorization: `Bearer ${token}` },
          responseType: "blob",
        })
        .then((resp) => {
          const pdf = window.URL.createObjectURL(
            new Blob([resp.data], { type: "application/pdf" })
          );
          SetWorkPDF(pdf);
        });
    })();

    // get all data about scientific work with reviews
    (async () => {
      await axios
        .get(`${URL_API}/ScientificWork/${Number(id)}`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .then((resp) => {
          if (!resp.data.mainAuthor.photo)
            resp.data.mainAuthor.photo = defaultPhoto;

          setData(resp.data);
        });
    })();
  }, [location]);

  return (
    <div>
      {data.mode === "Author" ? (
        <p className={style.path}>
          My profile / <span className={style.title}>My Work</span>
        </p>
      ) : (
        <p className={style.path}>
          Scientific works /{" "}
          <span className={style.title}>{data.scientificWork.title}</span>
        </p>
      )}

      <Information
        scientificWork={data.scientificWork}
        author={data.mainAuthor}
        status={data.status}
        mode={data.mode}
        workPDF={workPDF}
      />

      <div className={style.menu}>
        {data.mode !== "Participant" &&
          data.versions.map((version, i) => (
            <div key={i}>
              <VersionPanel
                version={version}
                mode={data.mode}
                authorPhoto={data.mainAuthor.photo}
                authorName={data.mainAuthor.name}
                scientificWorkId={data.scientificWork.id}
              />
            </div>
          ))}
      </div>
    </div>
  );
}