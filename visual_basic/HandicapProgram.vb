Imports System.IO
Imports System.Xml

Module HandicapProgram

    ' Please edit this string to match your local file
    Dim filePath As String = "C:\Users\Sidney\Documents\Development\Athensworks.GolfHandicap\Athensworks.GolfHandicap.Application\scores.xml"

    Class Round
        Private _Score As Integer
        Private _Slope As Integer
        Private _Rating As Double
        Private _Par As Integer
        Public Property Score() As Integer
            Get
                Return _Score
            End Get
            Set(ByVal value As Integer)
                _Score = value
            End Set
        End Property
        Public Property Slope() As Integer
            Get
                Return _Slope
            End Get
            Set(ByVal value As Integer)
                _Slope = value
            End Set
        End Property
        Public Property Rating() As Double
            Get
                Return _Rating
            End Get
            Set(ByVal value As Double)
                _Rating = value
            End Set
        End Property
        Public Property Par() As Integer
            Get
                Return _Par
            End Get
            Set(ByVal value As Integer)
                _Par = value
            End Set
        End Property

    End Class

    Sub Main()
        ' get the list of scores
        Dim rounds As List(Of Round) = Scores2List()
        ' compute the handicap 15.1
        Dim handicap As Double = Get_Handicap(rounds)
        ' output the result
        Console.Write("The handicap is: " & handicap.ToString())
        Console.ReadLine()
    End Sub
    Function Scores2List() As List(Of Round)
        ' load the XML file
        Dim scoresFile As New StreamReader(filePath)
        Dim scoresXML As String = scoresFile.ReadToEnd()
        scoresFile.Close()
        Dim doc As New XmlDocument
        doc.LoadXml(scoresXML)
        ' defined the XML node containing a round object
        Dim idNodes As XmlNodeList = doc.SelectNodes("scores/score")
        ' create a new list of rounds
        Dim rounds As New List(Of Round)
        ' populate the list of rounds
        For Each node In idNodes
            Dim newRound As New Round
            newRound.Score = Convert.ToInt32(node.ChildNodes(0).InnerText)
            newRound.Slope = Convert.ToInt32(node.ChildNodes(1).InnerText)
            newRound.Rating = Convert.ToDouble(node.ChildNodes(2).InnerText)
            newRound.Par = Convert.ToInt32(node.ChildNodes(3).InnerText)
            rounds.Add(newRound)
        Next
        ' return the list of rounds
        Scores2List = rounds
    End Function
    Function Get_Handicap(ScoreList As List(Of Round)) As Double
        Dim diff_list As New List(Of Double)
        Dim Result_diffs As New List(Of Double)
        For i = 0 To ScoreList.Count - 1
            Dim diff As Double = 0
            Dim c As Round = ScoreList(i)
            diff = (c.Score - c.Rating) * 113 / c.Slope
            diff_list.Add(diff)
        Next
        Result_diffs = get_correct_diffs(diff_list)
        Dim sum As Double = 0
        For i = 0 To Result_diffs.Count - 1
            Dim c As Double = Result_diffs(i)
            sum += c
        Next
        Dim result As Double = sum / Result_diffs.Count
        result = result * 0.96
        result = Math.Truncate(10 * result) / 10
        Get_Handicap = result
    End Function
    Function get_correct_diffs(org_difffs As List(Of Double))
        Dim result As New List(Of Double)
        Dim count As Integer = org_difffs.Count
        Dim num_diffs As Integer = NumLowest(count)
        org_difffs.Sort()
        For i = 0 To num_diffs - 1
            result.Add(org_difffs(i))
        Next
        get_correct_diffs = result
    End Function
    Function NumLowest(num As Integer) As Integer
        Select Case num
            Case 5
                NumLowest = 1
            Case 6
                NumLowest = 1
            Case 7
                NumLowest = 2
            Case 8
                NumLowest = 2
            Case 9
                NumLowest = 3
            Case 10
                NumLowest = 3
            Case 11
                NumLowest = 4
            Case 12
                NumLowest = 4
            Case 13
                NumLowest = 5
            Case 14
                NumLowest = 5
            Case 15
                NumLowest = 6
            Case 16
                NumLowest = 6
            Case 17
                NumLowest = 7
            Case 18
                NumLowest = 8
            Case 19
                NumLowest = 9
            Case 20
                NumLowest = 10
            Case Else
                NumLowest = 0
        End Select
    End Function

End Module
