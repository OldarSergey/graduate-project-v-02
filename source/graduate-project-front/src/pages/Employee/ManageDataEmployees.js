import './ManageDataEmployees.css'
import { Container, Row, Col, Button } from 'react-bootstrap';
import CardEmployee from '../../components/Employee/CardEmployee';
import { useState, useEffect} from 'react';
import { BiSearch } from 'react-icons/bi';

import {CFormSelect,CFormInput} from '@coreui/react';
const ManageDataEmployees =() =>{


    const [searchEmployee, setSearchEmployee] = useState("");
    const [sortEmployee, setSortEmployee] = useState("отсутствует");


    const handleSortChange = (event) => {
        setSortEmployee(event.target.value);
    };

    return(
   
   <Container fluid className='p-0'>
        <Row className='row-1 m-0 w-100'>
                <Col xs={2} className='select-employee'>
                    <CFormSelect className='select-h' value={sortEmployee} onChange={handleSortChange} style={{minWidth:"170px"}}>
                        <option value="Без сортировки">Без сортировки</option>
                        <option value="По фамилии">По фамилии</option>
                        <option value="По должности">По должности</option>
                        <option value="По отделу">По отделу</option>
                    </CFormSelect>
                </Col>
                <Col className="col-auto search-container" style={{marginLeft:"70px"}}>
                    <BiSearch className="search-icon" />
                    <input 
                    className='inputSearch' 
                    placeholder="Поиск..."
                    onChange={(event) => setSearchEmployee(event.target.value)}></input>
                </Col>
                
        </Row>
        <Row className='w-100 mt-3'  style={{ overflowY: 'auto', maxHeight:'80vh'}}>
            <Col className="d-flex flex-column w-100 h-100">
                <CardEmployee searchEmployee={searchEmployee} sortEmployee={sortEmployee}></CardEmployee>
            </Col>
        </Row>

           
    </Container>
       
      
    )
}
export default ManageDataEmployees;