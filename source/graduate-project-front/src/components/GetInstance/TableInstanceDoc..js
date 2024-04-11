import React from "react";
import "./TableInstanceDoc.css"

function TableInstanceDoc({ instancesDoc }) {
    return (
        <div className="table-responsive-2 m-3 outer-wrapper" style={{width:'100%', height:'100%'}}>
            <div className='table-wrapper'>
        <table className="table m-3 model-table-custom box-shadow table-bordered table-hover" style={{ width: '98%'}}>
                    <thead className="rectangle-6">
                        <tr>
                            <th className='th-custom'>Указал действие</th>
                            <th>Исполнитель действия</th>
                            <th>Действие с документом</th>
                            <th>Комментарий исполнителя</th>
                            <th>Начал работу</th>
                            <th>Выполнил работу</th>
                            <th className="personal-comment">Получено в работу</th>

                        </tr>
                    </thead>
                    
                    <tbody>
                        {instancesDoc.map((instance, index) => (
                            <tr key={index}>
                                <td data-label='Указал'>{instance.userSender}</td>
                                <td data-label='Исполнил'>{instance.userExecutor}</td>
                                <td data-label='Действие'>{instance.operation}</td>
                                <td  data-label=''>
                                    {instance.commentExecutor}
                                </td>
                                <td data-label='Начал'>{new Date(instance.started).toLocaleDateString()}</td>
                                <td data-label='Выполнил'>{new Date(instance.executed).toLocaleDateString()}</td>
                                <td className="personal-comment" data-label='Получил'>{new Date(instance.received).toLocaleDateString()}</td>
                            </tr>
                        ))}
                </tbody>
            </table>
            </div>
        </div>
    );
}
export default TableInstanceDoc;