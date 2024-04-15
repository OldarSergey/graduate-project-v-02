import { useState, useEffect} from 'react';
import axios from "axios";
import './CardEmployee.css';
import ModalDetailed from '../ModalWindow/Employee/ModalDetailed';
import "./CardEmployee.css"
import { Button, Card, CardBody, CardText, CardTitle } from 'react-bootstrap';
const CardEmployee = ({searchEmployee, sortEmployee})  => {
    const [modalActive, setModalActive] = useState(null); 
    const [employees, setEmployees] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/Employee?sortingOptions=${sortEmployee}`);
                setEmployees(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }           
        };
        fetchData();
    }, [sortEmployee]); 


    const filteredDocuments = employees.filter(employee => {
        return employee.fullName.toLowerCase().includes(searchEmployee.toLowerCase())
    })
    return (
    <>
        {filteredDocuments.map((employee, index) => (
          <Card key={index} className='card mt-2 ms-3' style={{ position: 'relative' }}>
          <CardBody className='box-shadow'>
              <CardTitle>{employee.fullName}</CardTitle>
              <div style={{ position: 'absolute', right: '20px', top: '10px', cursor: 'pointer' }}>
                  <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-star" viewBox="0 0 16 16">
                      <path d="M2.866 14.85c-.078.444.36.791.746.593l4.39-2.256 4.389 2.256c.386.198.824-.149.746-.592l-.83-4.73 3.522-3.356c.33-.314.16-.888-.282-.95l-4.898-.696L8.465.792a.513.513 0 0 0-.927 0L5.354 5.12l-4.898.696c-.441.062-.612.636-.283.95l3.523 3.356-.83 4.73zm4.905-2.767-3.686 1.894.694-3.957a.56.56 0 0 0-.163-.505L1.71 6.745l4.052-.576a.53.53 0 0 0 .393-.288L8 2.223l1.847 3.658a.53.53 0 0 0 .393.288l4.052.575-2.906 2.77a.56.56 0 0 0-.163.506l.694 3.957-3.686-1.894a.5.5 0 0 0-.461 0z" />
                  </svg>
                  
              </div>
      
              <CardText style={{ maxWidth: '500px', marginBottom: '2px' }}>{employee.department}</CardText>
              <CardText className='card-duty'>{employee.duty}</CardText>

              <div style={{ width: '100%', display: 'flex', justifyContent: 'flex-end', position: 'absolute', bottom: '10px', right: '10px' }}>
                  <Button className='btn-custom-employee' onClick={() => setModalActive(employee.id)} >Подробнее</Button>
              </div>
          </CardBody>
      </Card>
      
        ))}
       
        {modalActive !== null && (
            <ModalDetailed
                employeeId={modalActive}
                employee={employees.find(emp => emp.id === modalActive)}
                active={modalActive !== null}
                onClose={() => setModalActive(null)}
            />
        )}
    </>
    )
}

export default CardEmployee;
