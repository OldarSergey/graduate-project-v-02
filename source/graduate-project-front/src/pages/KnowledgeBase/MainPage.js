import axios from "axios";
import { Container, Row, Col } from 'react-bootstrap';
import React, { useState, useEffect, useRef } from 'react';
import "./MainPage.css"
import OutputTreeFoleder from "../../components/Knowledge/OutputTreeFoleder";

function MainPage(){

    return (
        <Container fluid className='p-0 archive-conteiner'> {/* Добавляем стили для прокрутки */}
   
        <Row className='w-100 row-hight'>
                <Col className="d-none-custom d-flex flex-column archive-col" style={{height:"98vh"}}>
                   
                    <Row className="row-archive-two" style={{minHeight:"45px"}}>
                        <p style={{fontSize:'30px', textAlign:'center', color:"white"}}>Проводник</p>
                    </Row>
                    <Row className="row-archive-three overflow-auto"> {/* Добавляем класс overflow-auto */}
                        <OutputTreeFoleder></OutputTreeFoleder>
                    </Row>
                    
                </Col>
                <Col className="w-100 m-3 " style={{height:"50px"}}>
                    <Row className="file-row ml-3">
                        
                    </Row>
                </Col>
        </Row>
        
    </Container>
    );
}


export default MainPage;