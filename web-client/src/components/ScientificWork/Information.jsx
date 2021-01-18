import React from "react";
import "../../App.css";
import { makeStyles } from "@material-ui/core/styles";
import { Button, Tooltip } from "@material-ui/core/";
import PreviewPDF from "./PreviewPDF";

export default function Information(props) {
  const style = makeStyles({
    main: {
      width: "80%",
      margin: "auto",
    },
    left: {
      width: 320,
      float: "left",
      height: 450,
      border: "2px solid black",
    },
    right: {
      width: "70%",
      float: "right",
    },
    status: {
      width: "100%",
      float: "left",
      textAlign: "left",
      paddingLeft: "5%",
      color: "red",
    },
    date: {
      width: "100%",
      float: "left",
      textAlign: "left",
      paddingLeft: "5%",
      fontSize: "12px",
    },
    h1: {
      width: "100%",
      float: "left",
      textAlign: "left",
      paddingLeft: "5%",
      fontSize: "30px",
    },
    author: {
      width: "45%",
      float: "left",
      paddingLeft: "5%",
      textAlign: "left",
    },
    shared: {
      width: "100%",
      float: "left",
      color: "grey",
    },
    photo: {
      width: "90%",
      borderRadius: "50%",
      height: 80,
    },
    leftTitle: {
      width: "28%",
      float: "left",
    },
    rightTitle: {
      width: "70%",
      float: "right",
    },
    authorName: {
      paddingTop: "5%",
      width: "100%",
      float: "right",
      fontWeight: "bold",
    },
    degree: {
      width: "100%",
      float: "right",
      fontSize: "12px",
    },
    university: {
      width: "100%",
      float: "right",
      fontSize: "12px",
      color: "grey",
    },
    authors: {
      width: "45%",
      float: "right",
      paddingLeft: "5%",
    },
    other: {
      width: "100%",
      float: "left",
      textAlign: "left",
      color: "grey",
    },
    otherName: {
      width: "100%",
      float: "left",
      textAlign: "left",
      marginTop: "6%",
      fontWeight: "bold",
    },
    text: {
      width: "85%",
      float: "left",
      textAlign: "left",
      paddingLeft: "5%",
    },
    btn: {
      textTransform: "none",
    },
    btn1: {
      textTransform: "none",
      marginLeft: "5%",
      float: "left",
    },
  })();

  const downloadFile = () => {
    const link = document.createElement("a");
    link.href = props.workPDF;
    link.download = `${props.scientificWork.title.replaceAll(" ", "-")}.pdf`;
    link.click();
  };

  return (
    <div className={style.main}>
      <div className={style.left}>
        <PreviewPDF pdf={props.workPDF} />
      </div>

      <div className={style.right}>
        <Tooltip title="Status" placement="top-start">
          <span className={style.status}>{props.status}</span>
        </Tooltip>

        {/* Panel includes status, date add work, date modification and category  */}
        <span className={style.date}>
          <span>{props.scientificWork.createDate}</span>
          <span>&nbsp; (Edited: {props.scientificWork.updateDate}) &nbsp;</span>
          <span>
            {" "}
            <Button variant="contained" color="primary" className={style.btn}>
              {props.scientificWork.specialization}
            </Button>{" "}
          </span>
        </span>
        <h1 className={style.h1}>{props.scientificWork.title}</h1>

        {/* Panel includes photo, name author, degree, univeristy */}
        <div className={style.author}>
          <span className={style.shared}>Shared by</span>
          <p className={style.leftTitle}>
            <img
              src={props.author.photo}
              className={style.photo}
              alt={props.author.name}
            ></img>
          </p>
          <p className={style.rightTitle}>
            <span className={style.authorName}>{props.author.name}</span>
            <span className={style.degree}>{props.author.degree}</span>
            <span className={style.university}>{props.author.university}</span>
          </p>
        </div>
        <div className={style.authors}>
          <span className={style.other}>Other authors</span>
          <span className={style.otherName}>
            {props.scientificWork.authors}
          </span>
        </div>
        <p className={style.text}>{props.scientificWork.description}</p>

        <Button
          variant="outlined"
          color="primary"
          className={style.btn1}
          onClick={downloadFile}
        >
          Download full work
        </Button>
        {props.mode === "Author" && (
          <Button variant="contained" color="primary" className={style.btn1}>
            Add new version
          </Button>
        )}
      </div>
    </div>
  );
}