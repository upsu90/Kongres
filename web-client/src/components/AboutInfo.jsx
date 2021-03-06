import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import "../App.css";

export default function AboutInfo(props) {
  const style = makeStyles({
    main: {
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      textAlign: "left",
      "@media (min-width: 768px) and (max-width: 1300px)": {
        fontSize: "14px",
        lineHeight: "16px",
      },
      "@media (max-width: 768px)": {
        fontSize: "10px",
        lineHeight: "16px",
        flexWrap: "wrap",
      },
    },
    left: {
      "@media (min-width: 768px)": {
        marginRight: "24px",
      },
    },
    right: {
      "@media (min-width: 768px)": {
        marginLeft: "24px",
      },
    },
    photo: {
      width: "592px",
      height: "374px",
      "@media (min-width: 1150px) and (max-width: 1300px)": {
        width: "440px",
        height: "274px",
      },
      "@media (min-width: 100px) and (max-width: 1150px)": {
        width: "380px",
        height: "240px",
      },
      "@media (max-width: 1000px)": {
        width: "264px",
        height: "180px",
      },
    },
  })();

  const [left, SetLeft] = React.useState(null);
  const [right, SetRight] = React.useState(null);

  const infos = [
    <h2>{props.head}</h2>,
    <p>{props.text}</p>,
    <a className={style.link} href={props.link}>
      {props.adnotation}
    </a>,
  ];

  const image = (
    <img src={props.path} className={style.photo} alt={props.alternativeText} />
  );

  useEffect(() => {
    SetLeft(
        props.isImageRight || window.innerWidth < 768 ? infos : image
    );
    SetRight(
        props.isImageRight || window.innerWidth < 768 ? image : infos
    );
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <div className={style.main}>
      <div className={style.left}>{left}</div>
      <div className={style.right}>{right}</div> 
    </div>
  );
}
