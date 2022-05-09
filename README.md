# QLSV
<div>
    <ul type="square" align="left">
      <li>Use programming language C#</li>
      <li>Author: Lê Minh Thành</li>
    </ul>
    <h1>Buổi 5b: Dapper</h1>
    <img align="center" src="https://github.com/minhthanh120/QLSV/blob/master/Dapper.png"/>
    <p style ="text-align: left;">Implement lớp dpConnector sử dụng Dapper để truy vấn dữ liệu và mapping với model</p>
    <p style ="text-align: left;">Tại đây có các hàm chức năng giống với hnbConnector sử dụng NHibernate như Load danh sách sinh viên, Chi tiết thông tin sinh viên, nhập điểm do cùng kế thừa interface IDataloader với hnbConnector</p>
    <p style ="text-align: left;">Sử dụng Framework Castlewindsor để Dependency injection lớp dpConnector</p>
    <h1>Buổi 5a: NHibernate</h1>
    <img align="center" src="https://github.com/minhthanh120/QLSV/blob/master/NHibernate.png"/>
    <p style ="text-align: left;">Cài đặt class NhibernateSession tạo các session</p>
    <p style ="text-align: left;">Cài đặt file config chứa thông tin driver sql, sql connection string</p>
    <p style ="text-align: left;">Mapping model với table, procedure trong MSSQL bằng file Model.hbn.xml, DTO.hbn.xml</p>
    <p style ="text-align: left;">Cài đặt lớp hnbConnector và cho lớp kết thừa interface của lớp DataLoader, tạo các hàm chức năng giống của lớp DataLoader đã làm ở buổi trước</p>
    <p style ="text-align: left;">Sử dụng Framework Castlewindsor để Dependency injection lớp hnbConnector</p>
    <h1>Buổi 4 Framework Castlewindsor</h1>
    <p style ="text-align: left;">Cài đặt installers trong class RepositoriesInstaller</p>
    <p style ="text-align: left;">Sử dụng installer này trong Program.Main() để đóng gói vào 1 container, và khi kết thúc chương trình ta Dispose container này</p>
    <h1>Buổi 3: Dependency injection, service</h1>
    <img align="center" src="https://github.com/minhthanh120/QLSV/blob/master/DI service.png"/>
    <img align="center" src="https://github.com/minhthanh120/QLSV/blob/master/a62a6bd54d70832eda61.jpg"/>
    <p style ="text-align: left;">Module hóa menu chương trình thành cách action function trong lớp ActionFunc </p>
    <p style ="text-align: left;">Lưu các tham số không đổi trong ConstParamemter</p>
    <p style ="text-align: left;">Từ lớp ActionFunc ta tương tác với CSDL bằng cách sử dụng Setter injection hoặc Constructor injection với interface của lớp DataLoader</p>
    <p style ="text-align: left;">Từ lớp DataLoader ta tương tác với CSDL bằng cách sử dụng Constructor injection với interface của lớp dbConnector</p>
    <p style ="text-align: left;">Sử dụng lớp dbConnector kết nối và tương tác với cơ sở dữ liệu, lớp DataLoader tương tác với dữ liệu của lớp dbConnector, ViewModel trong folder DTO như SinhviênDTO, MônHọcDTO để thực hiện khả năng hiển thị của chương trình, base Model như sinhvien, MonHoc, Diem phối hợp với dbConnetor tương tác với cơ sở dữ liệu</p>
    <h1>Buổi 2: SQL</h1>
    <img align="center" src="https://github.com/minhthanh120/QLSV/blob/master/a62a6bd54d70832eda61.jpg"/>
    <img align="center" src="https://github.com/minhthanh120/QLSV/blob/master/diagram db.jpg"/>
    <br/>
    <p style ="text-align: left;">Sử dụng lớp dbConnector kết nối và tương tác với cơ sở dữ liệu, ViewModel trong folder DTO như SinhviênDTO, MônHọcDTO để thực hiện khả năng hiển thị của chương trình, base Model như sinhvien, MonHoc, Diem phối hợp với dbConnetor tương tác với cơ sở dữ liệu</p>