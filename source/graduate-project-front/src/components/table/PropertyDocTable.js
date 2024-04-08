import React from 'react';
import "./PropertyDocTable.css"

function PropertyDocTable() {
    return (
        <div className='table-responsive div-table' style={{marginTop:'32px'}}>
            <table>
            <thead>
                <tr>
                    <th colSpan="2">Свойства</th>
                </tr>
                <tr>
                    <th>Наименование</th>
                    <th>Значение</th>
                </tr>
            </thead>
            <tbody>
            <tr>
                <td>John</td>
                <td>Doe</td>
            </tr>
            </tbody>
        </table>
        </div>
        
    );
}

export default PropertyDocTable;
